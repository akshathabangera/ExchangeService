using ExchangeService.Models;

namespace ExchangeService.Services
{
    public interface IExchangeService
    {
        Task<CurrencyConversionResult> ConvertCurrencyAsync(string from, string to, decimal amount);

    }
}