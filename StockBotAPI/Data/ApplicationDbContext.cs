using Microsoft.EntityFrameworkCore;
using StockBotAPI.Models;

namespace StockBotAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

            
        }

        public DbSet<Stock> Stocks { get; set;}
    }
}
