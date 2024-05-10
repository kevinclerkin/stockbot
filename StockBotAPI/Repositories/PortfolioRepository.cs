using Microsoft.EntityFrameworkCore;
using StockBotAPI.Data;
using StockBotAPI.Interfaces;
using StockBotAPI.Models;

namespace StockBotAPI.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;
        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            return await _context.Portfolios.Where(u => u.AppUserId == user.Id)
                .Select(stock => new Stock
                {
                    Id = stock.StockId,
                    Symbol = stock.Stock.Symbol,
                    CompanyName = stock.Stock.CompanyName,
                    Purchase = stock.Stock.Purchase,
                    LastDiv = stock.Stock.LastDiv,
                    Industry = stock.Stock.Industry,
                    MarketCap = stock.Stock.MarketCap
                }).ToListAsync();
        }

        public async Task<Portfolio> CreatePortfolio(Portfolio portfolio)
        {
            if(portfolio == null)
            {
                throw new ArgumentNullException();
            };

            var addPortfolio = _context.Portfolios.Add(portfolio);
            await _context.SaveChanges();

            return (portfolio);
        }
    }
}
