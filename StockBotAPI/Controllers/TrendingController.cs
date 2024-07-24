using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Interfaces;

namespace StockBotAPI.Controllers
{
    [Route("api/trending")]
    [ApiController]
    public class TrendingController : ControllerBase
    {
        private readonly IAlphaVService _alphaVService;

        public TrendingController(IAlphaVService alphaVService)
        {
            _alphaVService = alphaVService;
        }

        [HttpGet("{query}")]
        public async Task<IActionResult> GetLatestNews(string query)
        {
            var companies = await _alphaVService.GetTrendingNews(query);
            if (companies == null)
            {
                return NotFound();
            }

            return Ok(companies);
        }
    }
}

