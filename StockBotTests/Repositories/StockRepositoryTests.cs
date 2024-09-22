using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using StockBotAPI.Data;
using StockBotAPI.Models;
using StockBotAPI.Repositories;


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
                databaseContext.Stocks.Add(
                        new Stock()
                        {
                            Id = 1,
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
            return databaseContext;
        }

        [Fact]
        public async void StockRepo_GetAsync_ReturnsListOfStocks()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var stockRepository = new StockRepository(dbContext);

            //Act
            var result = stockRepository.GetAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<List<Stock>>>();


            
        }

        [Fact]
        public async void StockRepo_GetByIdAsync_ReturnsStock()
        {
            //Arrange
            int Id = 1;
            var dbContext = await GetDbContext();
            var stockRepository = new StockRepository(dbContext);

            //Act
            var result = stockRepository.GetByIdAsync(Id);
            
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Stock>>();
        }

        [Fact]
        public async void StockRepo_GetBySymbolAsync_ReturnsStock()
        {
            //Arrange
            string symbol = "AAPL";
            var dbContext = await GetDbContext();
            var stockRepository = new StockRepository(dbContext);

            //Act
            var result = stockRepository.GetBySymbolAsync(symbol);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Stock>>();
        }

        [Fact]
        public async void StockRepo_CreateStockAsync_ReturnsStock()
        {
            //Arrange
            var stock = A.Fake<Stock>();
            var dbContext = await GetDbContext();
            var stockRepository = new StockRepository(dbContext);

            //Act
            var result = stockRepository.CreateStockAsync(stock);

            //Assert
            result.Should().BeOfType<Task<Stock>>();
        }
    }
}
