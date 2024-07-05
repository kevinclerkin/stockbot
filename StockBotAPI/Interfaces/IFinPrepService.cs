using StockBotAPI.DTO;
using StockBotAPI.Models;

namespace StockBotAPI.Interfaces
{
    public interface IFinPrepService
    {
        Task<string> GetStockBySymbol(string symbol);

        Task<Stock> GetStockProfile(string symbol);

        Task<string> GetKeyMetrics(string symbol);

        Task<string> GetIncomeStatement(string symbol);
    }
}
