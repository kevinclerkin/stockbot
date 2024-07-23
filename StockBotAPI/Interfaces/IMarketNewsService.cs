using StockBotAPI.DTO.NewsDTOs;

namespace StockBotAPI.Interfaces
{
    public interface IMarketNewsService
    {
        Task<StockNewsDTO> GetNews(string symbol);
    }
}
