using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Controllers;
using StockBotAPI.DTO;
using StockBotAPI.Interfaces;
using StockBotAPI.Models;

namespace StockBotTests
{
    public class StockControllerTests
    {
        [Fact]
        public async void GetStock_ReturnsOkObjectResult_AsTypeStock()
        {
            //Arrange
            var repository = A.Fake<IStockRepository>();

            var stockController = new StockController(repository);

            //Act
            var result = await stockController.GetStockAsync();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Equals(typeof(Stock));
            
        }

        [Theory]
        [InlineData(1)]
        public async void GetById_ReturnsOkObjectResult_AsTypeStock(int id)
        {
            //Arrange
            var repository = A.Fake<IStockRepository>();

            var stockController = new StockController(repository);

            //Act
            var result = await stockController.GetById(id);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Equals(typeof(Stock));
        }

        [Fact]
        public async void CreateStock_ReturnsOkObjectResult_AsTypeStock()
        {
            //Arrange
            var stockDTO = new CreateStockDTO();
            var repository = A.Fake<IStockRepository>();

            var stockController = new StockController(repository);

            //Act
            var result = await stockController.Create(stockDTO);

            //Assert
            result.Should().BeOfType<CreatedAtActionResult>();
            result.Equals(typeof(StockDTO));
            result.Equals(typeof(Stock));
            result.Should().NotBeOfType<CreateStockDTO>();
        }
    }
}