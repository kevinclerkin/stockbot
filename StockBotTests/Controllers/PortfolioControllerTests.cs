using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Controllers;
using StockBotAPI.Interfaces;
using StockBotAPI.Models;
using System.Security.Claims;


namespace StockBotTests.Controllers
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

        [Fact(Skip = "Conflict with static claims extensions method in extensions")]
        public async void GetPortfolio_ReturnsPortfolioList_OfTypeStock()
        {
            //Arrange
            var user = new AppUser()
            {
                Id = "1",
                Email = "davidsmith@gmail.com",
                UserName = "david1",
            };

            var newUser = A.Fake<AppUser>();
            

            var claims = new List<Claim>{
            new Claim(ClaimTypes.Name, "David Smith")};
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);


            A.CallTo(() => _userManager.GetUserName(claimsPrincipal)).Returns(ClaimTypes.Name);

            var newPortfolio = A.Fake<List<Stock>>();

            var fakePortfolio = new List<Stock>
            {
                new Stock{Id = 1, CompanyName= "Apple", Industry = "Technology", LastDiv = 1, MarketCap = 200000, Portfolio = new List<Portfolio>(), Purchase=190, Symbol="AAPL" }
            };

            A.CallTo(() => _portfolioRepository.GetUserPortfolio(newUser)).Returns(newPortfolio);


            //Act
            var appUser = await _userManager.FindByNameAsync(user.UserName!);
            var portfolio = await _portfolioRepository.GetUserPortfolio(appUser!);
            var result = await _portfolioController.GetPortfolio();

           


            //Assert
            fakePortfolio.Should().BeOfType<OkObjectResult>();
            Assert.NotNull(portfolio);
            result.Should().BeOfType<OkObjectResult>();
            (result as OkObjectResult)!.Value.Should().BeAssignableTo<List<Stock>>();
        }

        [Fact(Skip = "Conflict with static claims extensions method in extensions")]
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

            A.CallTo(() => _userManager.FindByNameAsync(userName))!.Returns(Task.FromResult(appUser));
            A.CallTo(() => _stockRepository.GetBySymbolAsync(symbol))!.Returns(Task.FromResult<Stock>(null!));
            A.CallTo(() => _finPrepService.GetStockProfile(symbol)).Returns(Task.FromResult<Stock>(null!));

            // Act
            var result = await _portfolioController.CreatePortfolio(symbol);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>().Which.Value.Should().Be("Stock does not exist");
        }
    }
}
