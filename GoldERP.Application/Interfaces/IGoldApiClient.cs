using GoldERP.Shared.Models;

namespace GoldERP.Application.Interfaces;

public interface IGoldApiClient
{
    Task<GoldApiResponse?> GetGoldPriceAsync();
    Task<GoldApiResponse?> GetSilverPriceAsync();
}