using System.Text.Json;
using GoldERP.Application.Interfaces;

namespace GoldERP.Infrastructure.External.Currency;

public class CurrencyService : ICurrencyService
{
    private readonly HttpClient _httpClient;

    public CurrencyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> GetUsdToInrRateAsync()
    {
        var response = await _httpClient.GetAsync("https://open.er-api.com/v6/latest/USD");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        using var document = JsonDocument.Parse(json);

        return document.RootElement
                       .GetProperty("rates")
                       .GetProperty("INR")
                       .GetDecimal();
    }
}