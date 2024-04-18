using StockBotAPI.Interfaces;
using StockBotAPI.Models;

namespace StockBotAPI.Repositories
{
    public class StockRepository : IStockRepository
    {
        public Task<List<Stock>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Stock> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
