namespace GoldERP.Application.Interfaces;

public interface ICurrencyService
{
    Task<decimal> GetUsdToInrRateAsync();
}