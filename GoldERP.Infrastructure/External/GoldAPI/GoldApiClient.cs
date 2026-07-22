using System.Text.Json;
using GoldERP.Application.Interfaces;
using GoldERP.Shared.Models;

namespace GoldERP.Infrastructure.External.GoldApi;

public class GoldApiClient : IGoldApiClient
{
    private readonly HttpClient _httpClient;

    public GoldApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.gold-api.com/");
    }

    public async Task<GoldApiResponse?> GetGoldPriceAsync()
    {
        var response = await _httpClient.GetAsync("price/XAU");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<GoldApiResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
    }

    public async Task<GoldApiResponse?> GetSilverPriceAsync()
    {
        var response = await _httpClient.GetAsync("price/XAG");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<GoldApiResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
    }
}