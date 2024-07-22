using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Controllers;
using StockBotAPI.DTO;
using StockBotAPI.Interfaces;
using StockBotAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockBotTests.Controllers
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
            string company = "Apple Inc";
            A.CallTo(() => _finPrepService.GetStockBySymbol(symbol)).Returns(company);

            //Act
            var controllerResult = await _stockDataController.SearchCompany(symbol);

            //Assert
            controllerResult.Should().BeOfType<OkObjectResult>();
            (controllerResult as OkObjectResult)!.Value.Should().BeAssignableTo<string>();



        }

        [Fact]
        public async void StockData_GetCompanyProfile_ReturnsTypeOfStock()
        {
            //Arrange
            string symbol = "TSLA";
            var profiles = A.Fake<Stock>();
            A.CallTo(() => _finPrepService.GetStockProfile(symbol)).Returns(profiles);

            //Act
            var result = await _stockDataController.CompanyProfile(symbol);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            (result as OkObjectResult)!.Value.Should().BeAssignableTo<Stock>();
        }

        [Fact]
        public async void StockData_GetCompanyOverview_ReturnsTypeOfFinPrepDTO()
        {
            //Arrange
            string symbol = "MSFT";
            var companyOverview = A.Fake<FinPrepDTO>();
            A.CallTo(() => _finPrepService.GetCompanyOverview(symbol)).Returns(companyOverview);

            //Act
            var result = await _stockDataController.CompanyOverview(symbol);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            (result as OkObjectResult)!.Value.Should().BeAssignableTo<FinPrepDTO>();
        }

        [Fact]
        public async void StockData_GetCompanyMetrics_ReturnsTypeOfString()
        {
            //Arrange
            string symbol = "NVDA";
            string companyMetrics = "Metrics";
            A.CallTo(() => _finPrepService.GetKeyMetrics(symbol)).Returns(companyMetrics);

            //Act
            var result = await _stockDataController.CompanyMetrics(symbol);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            (result as OkObjectResult)!.Value.Should().BeAssignableTo<string>();
        }

        [Fact]
        public async void StockData_GetCompanyIncome_ReturnsTypeOfString()
        {
            //Arrange
            string symbol = "AMZN";
            string companyIncome = "Income";
            A.CallTo(() => _finPrepService.GetIncomeStatement(symbol)).Returns(companyIncome);

            //Act
            var result = await _stockDataController.CompanyIncome(symbol);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            (result as OkObjectResult)!.Value.Should().BeAssignableTo<string>();
        }


    }
}
