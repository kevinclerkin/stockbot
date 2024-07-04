using StockBotAPI.DTO;
using StockBotAPI.Interfaces;
using System.Text.Json;


namespace StockBotAPI.Services
{
    public class FinPrepService : IFinPrepService
    {
        private readonly HttpClient _httpClient;

        private readonly IConfiguration _configuration;

        public FinPrepService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<FinPrepDTO> GetStockBySymbol(string symbol)
        {
            try
            {
                var apiKey = _configuration["FMPKey"];
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new InvalidOperationException("API key for Financial Modeling Prep is missing.");
                }

                var requestUrl = $"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={apiKey}";
                var result = await _httpClient.GetAsync(requestUrl);

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var stocks = JsonSerializer.Deserialize<FinPrepDTO[]>(content);
                    return stocks?.FirstOrDefault();
                }
                else
                {
                    Console.WriteLine($"Error: {result.StatusCode}");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }
        
        
    }
}
