using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Controllers;
using StockBotAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockBotTests
{
    public class StockDataControllerTests
    {
        private readonly IFinPrepService _finPrepService;
        private readonly StockDataController _stockDataController;

        public StockDataControllerTests()
        {
            _finPrepService = A.Fake<IFinPrepService>();
            _stockDataController = new StockDataController(_finPrepService);
        }

        [Fact]
        public async void StockData_SearchCompany_ReturnsCompanyAsString()
        {
            //Arrange
            string symbol = "AAPL";

            //Act
            var result = await _finPrepService.GetStockBySymbol(symbol);
            var controllerResult = await _stockDataController.SearchCompany(symbol);
            
            //Assert
            result.Should().BeOfType<string>();
            controllerResult.Should().BeOfType<OkObjectResult>();
            (controllerResult as OkObjectResult)!.Value.Should().BeAssignableTo<string>();

            

        }
    }
}
