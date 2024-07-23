using StockBotAPI.DTO.NewsDTOs;

namespace StockBotAPI.Interfaces
{
    public interface IMarketNewsService
    {
        Task<string> GetNews(string symbol);

        Task<TrendingDTO> GetTrending();
    }
}
