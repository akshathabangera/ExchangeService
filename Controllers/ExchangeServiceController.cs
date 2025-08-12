using ExchangeService.Models;
using ExchangeService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ExchangeService.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeServiceController : ControllerBase
{
    private readonly IExchangeService _currencyService;

    public ExchangeServiceController(IExchangeService currencyService)
    {
        _currencyService = currencyService;
    }

    [HttpPost]
    public async Task<IActionResult> Convert([FromBody] ExchangeRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid Request");
        if (request.Amount<=0)
            return BadRequest("Amount must be greater than zero!");

        try
        {
            var result = await _currencyService.ConvertCurrencyAsync(request.InputCurrency.ToUpper(), request.OutputCurrency.ToUpper(), request.Amount);
            return Ok(result);         
        }
        catch (ArgumentException ex )
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {            
            return StatusCode(500, new { error = "Unexpected error" });
        }
    }
}
