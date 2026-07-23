using System.Net.Http.Json;
using GoldERP.Application.Features.GoldRate.DTOs;
using GoldERP.Shared.Common;

namespace GoldERP.Blazor.Services;

public class GoldRateApiService
{
    private readonly HttpClient _httpClient;

    public GoldRateApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<GoldRateResponseDto>?> GetGoldRatesAsync()
    {
        Console.WriteLine($"Calling: {_httpClient.BaseAddress}api/GoldRate/GetLiveRates");

        var response = await _httpClient.GetAsync("api/GoldRate/GetLiveRates");

        Console.WriteLine($"Status Code: {response.StatusCode}");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ApiResponse<GoldRateResponseDto>>();
    }
}