using StockBotAPI.Interfaces;
using System.Text.Json;

namespace StockBotAPI.Services
{
    public class AlphaVService : IAlphaVService
    {
        private readonly HttpClient _httpClient;

        private readonly IConfiguration _configuration;

        public AlphaVService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            _configuration = configuration;
        }

       
        public async Task<Dictionary<string, dynamic>> GetTrendingNews(string symbol)
        {
            try
            {
                var apiKey = _configuration["AVKey"];
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new InvalidOperationException("API key for Alpha V is missing.");
                }

                var dateTime = DateTime.UtcNow - TimeSpan.FromHours(6);
                string dateTimeString = dateTime.ToString("yyyyMMddTHHmm");

                var requestUrl = $"https://www.alphavantage.co/query?function=NEWS_SENTIMENT&tickers={symbol}&time_from={dateTimeString}&sort=RELEVANCE&apikey={apiKey}";
                var response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };


                var jsonData = JsonSerializer.Deserialize<Dictionary<string, object>>(responseBody, options);

                return jsonData!;


            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null!;
            }

        }

        public async Task<string> GetSentiment(string symbol)
        {
            try
            {
                var apiKey = _configuration["AVKey"];
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new InvalidOperationException("API key for AlphaV is missing.");
                }

                var dateTime = DateTime.UtcNow - TimeSpan.FromHours(6);
                string dateTimeString = dateTime.ToString("yyyyMMddTHHmm");

                var requestUrl = $"https://www.alphavantage.co/query?function=NEWS_SENTIMENT&tickers={symbol}" +
                    $"&time_from={dateTimeString}&sort=RELEVANCE&apikey={apiKey}";
                
                var response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    // Parse JSON and extract the overall_sentiment_label for the first article
                    using (JsonDocument doc = JsonDocument.Parse(content))
                    {
                        JsonElement root = doc.RootElement;
                        JsonElement feed;
                        if (root.TryGetProperty("feed", out feed) && feed.GetArrayLength() > 0)
                        {
                            var firstArticle = feed[0];
                            if (firstArticle.TryGetProperty("overall_sentiment_label", out JsonElement sentimentLabel))
                            {
                                return sentimentLabel.GetString()!;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null!;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null!;
            }

            return null!;
        }
    }

    
}
