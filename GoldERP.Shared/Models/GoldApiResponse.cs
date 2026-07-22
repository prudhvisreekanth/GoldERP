namespace GoldERP.Shared.Models;

public class GoldApiResponse
{
    public string Currency { get; set; } = string.Empty;
    public string CurrencySymbol { get; set; } = string.Empty;
    public decimal ExchangeRate { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Symbol { get; set; } = string.Empty;
    public DateTime UpdatedAt { get; set; }
    public string UpdatedAtReadable { get; set; } = string.Empty;
}