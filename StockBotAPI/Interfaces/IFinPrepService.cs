using StockBotAPI.DTO;

namespace StockBotAPI.Interfaces
{
    public interface IFinPrepService
    {
        Task<FinPrepDTO> GetStockBySymbol(string symbol);
    }
}
