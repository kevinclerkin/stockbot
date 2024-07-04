using Microsoft.AspNetCore.Mvc;
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
                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={_configuration["FMPKey"]}");
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonSerializer.Deserialize<FinPrepDTO[]>(content)!;
                    var stock = tasks[0];
                    if (stock != null)
                    {
                        
                    }
                    return null!;
                }
                return null!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null!;
            }
        }
        
        
    }
}
