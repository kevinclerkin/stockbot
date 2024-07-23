using StockBotAPI.DTO.NewsDTOs;
using StockBotAPI.Interfaces;
using System.Text.Json;

namespace StockBotAPI.Services
{
    public class MarketNewsService : IMarketNewsService
    {
        private readonly HttpClient _httpClient;

        private readonly IConfiguration _configuration;

        public MarketNewsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
        }

        public async Task<string> GetNews(string symbol)
        {
            try
            {
                var apiKey = _configuration["MarketAuxKey"];
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new InvalidOperationException("API key for MarketAux is missing.");
                }

                var requestUrl = $" https://api.marketaux.com/v1/news/all?symbols={symbol}&filter_entities=true&language=en&api_token={apiKey}";
                var response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if(content != null)
                    {
                        return content;
                    }
                    return null;

                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }
    }
}
