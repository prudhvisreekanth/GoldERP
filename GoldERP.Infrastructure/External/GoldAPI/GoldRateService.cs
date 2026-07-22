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
        {
            throw new Exception("Unable to fetch gold/silver prices.");
        }        

        var usdToInr = await _currencyService.GetUsdToInrRateAsync();

        decimal gold24K = (gold.Price * usdToInr) / 31.1035m;
        decimal gold22K = gold24K * 22 / 24;
        decimal silverPrice = (silver.Price * usdToInr) / 31.1035m;

        return new GoldRateResponseDto
        {
            Gold24K = Math.Round(gold24K, 2),
            Gold22K = Math.Round(gold22K, 2),
            Silver = Math.Round(silverPrice, 2),
            Currency = "INR",
            LastUpdated = gold.UpdatedAt
        };
    }
}