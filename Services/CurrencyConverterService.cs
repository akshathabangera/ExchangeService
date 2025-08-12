using ExchangeService.Controllers;
using ExchangeService.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace ExchangeService.Services;

public class CurrencyConverterService : IExchangeService
{
    private readonly HttpClient _httpClient;
    private readonly ExchangeRateApiOptions _options;

    public CurrencyConverterService(HttpClient httpClient, IOptions<ExchangeRateApiOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<CurrencyConversionResult> ConvertCurrencyAsync(string from, string to, decimal amount)
    {       
      
        var data = await _httpClient.GetFromJsonAsync<ExchangeResponse>(from);

        if (data == null|| data.rates==null || !data.rates.ContainsKey(to.ToUpper()))
           throw new InvalidOperationException($"Currency Conversion failed");

        var rate = data.rates[to.ToUpper()];
        var converted = Math.Round(amount * rate, 2);

        return new CurrencyConversionResult
        {
            InputCurrency = from,
            OutputCurrency = to,          
            Amount = amount,
            Value = converted           
        };
    }
}
