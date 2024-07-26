using StockBotAPI.DTO.NewsDTOs;

namespace StockBotAPI.Interfaces
{
    public interface IMarketNewsService
    {
        Task<Dictionary<string, dynamic>> GetNews(string symbol);

        Task<Dictionary<string, dynamic>> GetTrending();
    }
}
