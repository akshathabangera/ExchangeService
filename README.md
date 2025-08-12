**********Features****
Converts currency amounts from one currency code to another
Uses HttpClientFactory for calling the external ExchangeRate-API - https://open.er-api.com/v6/latest/
Supports JSON and plain text responses based on the Accept header
Input validation with data annotations
Swagger UI for API documentation (in development mode)

***Getting Started***
Prerequisites
.NET 7 SDK or later
NO API KEY REQUIRED 

**Setup**
1)Clone the repository - https://github.com/akshathabangera/ExchangeService.git and run locally 
2) Build and run the application:
>dotnet build
>dotnet run
3) The API will be available at http://localhost:5000 (or the port displayed in the console).

**Testing the API**
Example curl command to convert 5 AUD to USD with plain text response:

curl -X POST "http://localhost:5000/ExchangeService" \
-H "accept: text/plain" \
-H "Content-Type: application/json" \
-d '{"amount":5,"inputCurrency":"AUD","outputCurrency":"USD"}'

**Areas for Improvement**
Error Handling & Logging:
Add comprehensive logging and better exception handling to capture external API failures and internal errors.
Add authentication/authorization if the API is exposed publicly.
Input Validation:More rigorous validation like currencycodes
Caching: Cache exchange rate responses to reduce calls to the external API and improve performance.
Rate Limiting: Protect the API from abuse by adding throttling or rate limiting.
Unit and Integration Testing: Add tests covering service layers, controllers, and HttpClient mocking.
API Versioning to support backward compatibility for clients.
