﻿using Microsoft.AspNetCore.Authorization;
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
            var portfolio = await _portfolioRepository.GetUserPortfolio(appUser!);

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
            var username = User.GetUser();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepository.GetBySymbolAsync(symbol);

            if (stock == null)
            {

                if (stock == null)
                {
                    return BadRequest("Stock does not exist");
                }
                else
                {
                    await _stockRepository.CreateStockAsync(stock);
                }
            }

            if (stock == null)
            {

                return BadRequest("Stock not found");

            }

            var portfolio = await _portfolioRepository.GetUserPortfolio(appUser!);

            if (portfolio.Any(e => e.Symbol.ToLower() == symbol.ToLower()))
            
            {
                return BadRequest("Cannot add same stock to portfolio");
            
            };

            var portfolioModel = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = appUser!.Id
            };

            await _portfolioRepository.CreatePortfolioAsync(portfolioModel);

            if (portfolioModel == null)
            {
                return StatusCode(500);
            }
            else
            {
                return StatusCode(200);
            }
        }
    }
}
