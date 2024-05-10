using StockBotAPI.Models;

namespace StockBotAPI.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AppUser user);

        Task<Portfolio> CreatePortfolioAsync(Portfolio portfolio);

        Task<Portfolio> DeletePortfolio(AppUser user, string symbol);

    }
}
