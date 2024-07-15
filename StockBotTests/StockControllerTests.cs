using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Controllers;
using StockBotAPI.Interfaces;
using StockBotAPI.Models;

namespace StockBotTests
{
    public class StockControllerTests
    {
        [Fact]
        public async void GetStock_ReturnsOkObjectResult_WithStock()
        {
            //Arrange
            var repository = A.Fake<IStockRepository>();

            var stockController = new StockController(repository);

            A.CallTo(() => repository.GetAsync()).Returns(new List<Stock>());

            //Act
            var result = await stockController.GetStockAsync();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            
        }
    }
}