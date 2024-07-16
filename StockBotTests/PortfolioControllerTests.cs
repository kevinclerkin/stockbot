using Azure.Identity;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Controllers;
using StockBotAPI.Interfaces;
using StockBotAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockBotTests
{
    public class PortfolioControllerTests
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IStockRepository _stockRepository;

        private readonly IPortfolioRepository _portfolioRepository;

        private readonly IFinPrepService _finPrepService;

        private readonly PortfolioController _portfolioController;

        public PortfolioControllerTests()
        {
            _userManager = A.Fake<UserManager<AppUser>>();
            _stockRepository = A.Fake<IStockRepository>();
            _portfolioRepository = A.Fake<IPortfolioRepository>();
            _finPrepService = A.Fake<IFinPrepService>();
            _portfolioController = new PortfolioController(_userManager, _stockRepository, _portfolioRepository, _finPrepService);

            
        }

        [Fact]
        public async void GetPortfolio_ReturnsPortfolioList_OfTypeStock()
        {
            //Arrange
            var user = new AppUser();

            /*var fakePortfolio = new List<Stock>
            {
                new Stock{Id = 1, CompanyName= "Apple", Industry = "Technology", LastDiv = 1, MarketCap = 200000, Portfolio = new List<Portfolio>(), Purchase=190, Symbol="AAPL" }
            };*/

            //A.CallTo(() => _portfolioRepository.GetUserPortfolio(user)).Returns(fakePortfolio);


            //Act
            var appUser = await _userManager.FindByNameAsync(user.UserName!);
            var portfolio = await _portfolioRepository.GetUserPortfolio(appUser);
           


            //Assert
            //fakePortfolio.Should().BeOfType<OkObjectResult>();
            Assert.NotNull(portfolio);
        }

        /*[Fact]
        public async Task CreatePortfolio_ReturnsBadRequest_WhenStockDoesNotExist()
        {
            // Mock User
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Name, "testuser"),
            }, "mock"));

            _portfolioController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            // Arrange
            var symbol = "INVALID";
            var userName = "testuser";
            var appUser = new AppUser { UserName = userName };

            A.CallTo(() => _userManager.FindByNameAsync(userName)).Returns(Task.FromResult(appUser));
            A.CallTo(() => _stockRepository.GetBySymbolAsync(symbol)).Returns(Task.FromResult<Stock>(null));
            A.CallTo(() => _finPrepService.GetStockProfile(symbol)).Returns(Task.FromResult<Stock>(null));

            // Act
            var result = await _portfolioController.CreatePortfolio(symbol);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>().Which.Value.Should().Be("Stock does not exist");
        }*/
    }
}
