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
        public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepository)
        {
            _userManager = userManager;

            _stockRepository = stockRepository;
            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPortfolio()
        {
            var userName = User.GetUser();
            var appUser = await _userManager.FindByEmailAsync(userName);

            return Ok();

        }
    }
}
