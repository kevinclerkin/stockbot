using StockBotAPI.Interfaces;

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

        public Task<string> GetNews(string symbol)
        {
            throw new NotImplementedException();
        }
    }
}
