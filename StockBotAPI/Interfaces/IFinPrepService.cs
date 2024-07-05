using StockBotAPI.DTO;

namespace StockBotAPI.Interfaces
{
    public interface IFinPrepService
    {
        Task<string> GetStockBySymbol(string symbol);

        Task<FinPrepDTO> GetStockProfile(string symbol);
    }
}
