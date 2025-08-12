using ExchangeService;
using ExchangeService.Services;

var builder = WebApplication.CreateBuilder(args);

// Bind config section to options
builder.Services.Configure<ExchangeRateApiOptions>(
    builder.Configuration.GetSection("ExchangeRateApi")
);

// Register HttpClient with base address from config
builder.Services.AddHttpClient<IExchangeService, CurrencyConverterService>((sp, client) =>
{
    var options = sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<ExchangeRateApiOptions>>().Value;
    client.BaseAddress = new Uri(options.BaseUrl);
    client.DefaultRequestHeaders.Add("Accept", "text/plain"); 
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.Run();
