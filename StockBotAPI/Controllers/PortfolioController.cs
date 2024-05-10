using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Extensions;
using StockBotAPI.Interfaces;
using StockBotAPI.Models;

namespace StockBotAPI.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IStockRepository _stockRepository;

        private readonly IPortfolioRepository _portfolioRepository;
        public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepository, IPortfolioRepository portfolioRepository)
        {
            _userManager = userManager;

            _stockRepository = stockRepository;

            _portfolioRepository = portfolioRepository;

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPortfolio()
        {
            var userName = User.GetUser();
            var appUser = await _userManager.FindByEmailAsync(userName);
            var portfolio = await _portfolioRepository.GetUserPortfolio(appUser);

            if(portfolio == null)
            {
                return NotFound();
            }

            return Ok(portfolio);

        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CreatePortfolio(string symbol)
        {
            return Ok();
        }
    }
}
