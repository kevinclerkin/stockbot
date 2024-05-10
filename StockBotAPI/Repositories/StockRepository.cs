using Microsoft.EntityFrameworkCore;
using StockBotAPI.Data;
using StockBotAPI.Interfaces;
using StockBotAPI.Models;

namespace StockBotAPI.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Stock>> GetAsync()
        {
            return await _context.Stocks.ToListAsync();

            
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FirstOrDefaultAsync(i => i.Id == id);

           
        }

        public async Task<Stock?> GetBySymbolAsync(string symbol)
        {
            return await _context.Stocks.FirstOrDefaultAsync(i => i.Symbol == symbol);
        }
    }
}
