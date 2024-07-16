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
        private readonly StockController _stockController;
        private readonly IStockRepository _repository;

        public StockControllerTests()
        {
            //Arrange
            _repository = A.Fake<IStockRepository>();
            _stockController = new StockController(_repository);
        }

        [Fact]
        public async void GetStock_ReturnsOkObjectResult_AsTypeStock()
        {

            //Act
            var result = await _stockController.GetStockAsync();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            (result as OkObjectResult)!.Value.Should().BeAssignableTo<List<Stock>>();
            
        }

        [Theory]
        [InlineData(1)]
        public async void GetById_ReturnsOkObjectResult_AsTypeStock(int id)
        {

            //Act
            var result = await _stockController.GetById(id);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Equals(typeof(Stock));
            (result as OkObjectResult)!.Value.Should().BeAssignableTo<Stock>();
        }

        [Fact]
        public async void CreateStock_ReturnsOkObjectResult_AsTypeStock()
        {
            //Arrange
            var stockDTO = new CreateStockDTO();
            

            //Act
            var result = await _stockController.Create(stockDTO);

            //Assert
            result.Should().BeOfType<CreatedAtActionResult>();
            result.Equals(typeof(StockDTO));
            result.Should().NotBeOfType<CreateStockDTO>();
            (result as CreatedAtActionResult)!.Value.Should().BeAssignableTo<StockDTO>();
        }
    }
}