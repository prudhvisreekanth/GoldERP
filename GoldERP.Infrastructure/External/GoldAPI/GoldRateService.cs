using GoldERP.Application.Features.GoldRate.DTOs;
using GoldERP.Application.Interfaces;

namespace GoldERP.Infrastructure.Services;

public class GoldRateService : IGoldRateService
{
    private readonly IGoldApiClient _goldApiClient;
    private readonly ICurrencyService _currencyService;

    public GoldRateService(IGoldApiClient goldApiClient,
    ICurrencyService currencyService)
    {
        _goldApiClient = goldApiClient;
        _currencyService = currencyService;
    }

    public async Task<GoldRateResponseDto> GetLiveRatesAsync()
    {
        var gold = await _goldApiClient.GetGoldPriceAsync();
        var silver = await _goldApiClient.GetSilverPriceAsync();

        if (gold == null || silver == null)
            throw new Exception("Unable to fetch gold/silver prices.");

        var usdToInr = await _currencyService.GetUsdToInrRateAsync();

        // ===========================
        // GOLD CALCULATION
        // ===========================

        // Step 1: Convert USD/Ounce -> INR/Gram
        decimal baseGoldRate = (gold.Price * usdToInr) / 31.1035m;

        // Step 2: Import Duty (15%)
        decimal importDuty = baseGoldRate * 0.15m;
        decimal afterImportDuty = baseGoldRate + importDuty;

        // Step 3: Bank Handling Charges
        decimal bankCharges = 12.50m;
        decimal afterBankCharges = afterImportDuty + bankCharges;

        // Step 4: GST (3%)
        decimal gst = afterBankCharges * 0.03m;
        decimal final24KRate = afterBankCharges + gst;

        // Step 5: 22K Gold
        decimal final22KRate = final24KRate * 22 / 24;

        // ===========================
        // SILVER CALCULATION
        // ===========================

        decimal silverBaseRate = (silver.Price * usdToInr) / 31.1035m;
        decimal finalSilverRate = silverBaseRate;

        return new GoldRateResponseDto
        {
            Gold24K = Math.Round(final24KRate, 2),
            Gold22K = Math.Round(final22KRate, 2),
            Silver = Math.Round(finalSilverRate, 2),
            Currency = "INR",
            LastUpdated = gold.UpdatedAt
        };
    }
}