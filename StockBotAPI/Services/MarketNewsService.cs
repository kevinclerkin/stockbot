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

        public async Task<Dictionary<string, dynamic>> GetNews(string symbol)
        {
            try
            {
                var apiKey = _configuration["AUX_API_KEY"];
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new InvalidOperationException("API key for MarketAux is missing.");
                }

                var requestUrl = $" https://api.marketaux.com/v1/news/all?symbols={symbol}&filter_entities=true&language=en&api_token={apiKey}";
                var response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var stockNews = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(content);
                    if(stockNews != null)
                    {
                        return stockNews;
                    }
                    return null!;

                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null!;
            }
        }

        public async Task<Dictionary<string, dynamic>> GetTrending()
        {
            try
            {
                var apiKey = _configuration["AUX_API_KEY"];
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new InvalidOperationException("API key for MarketAux is missing.");
                }

                var requestUrl = $"https://api.marketaux.com/v1/entity/trending/aggregation?countries=us,ca&min_doc_count=2&published_after=2024-07-22T14:39&language=en&api_token={apiKey}";
                var response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //var trending = JsonSerializer.Deserialize<TrendingDTO[]>(content);
                    //var bestPick = trending?.FirstOrDefault();

                    var trending = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(content);
                    if(trending != null)
                    {
                        return trending;
                    }
                    return null!;

                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null!;
            }

        }
    }
}
