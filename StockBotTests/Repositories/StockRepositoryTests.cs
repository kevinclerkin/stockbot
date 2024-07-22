using Microsoft.EntityFrameworkCore;
using StockBotAPI.Data;
using StockBotAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockBotTests.Repositories
{
    public class StockRepositoryTests
    {
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            if(await databaseContext.Stocks.CountAsync() <= 0)
            {
                for(int i=0; i<10; i++)
                {
                    databaseContext.Stocks.Add(
                        new Stock()
                        {
                            Id = i,
                            Symbol = "AAPL",
                            CompanyName = "Apple",
                            MarketCap = 1000000,
                            LastDiv = 1,
                            Industry = "Tech",
                            Portfolio = new List<Portfolio>(),
                            Purchase = 244
                        }
                        );
                    await databaseContext.SaveChangesAsync();
                }
                
            }
            return databaseContext;
        }
    }
}
