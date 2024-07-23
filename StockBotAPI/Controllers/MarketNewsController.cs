using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Interfaces;
using StockBotAPI.Services;

namespace StockBotAPI.Controllers
{
    [Route("api/market-news")]
    [ApiController]
    public class MarketNewsController : ControllerBase
    {
        private readonly IMarketNewsService _marketNewsService;

        public MarketNewsController(IMarketNewsService marketNewsService)
        {
            _marketNewsService = marketNewsService;
        }

        [HttpGet("{query}")]
        public async Task<IActionResult> GetMarketNews(string query)
        {
            var news = await _marketNewsService.GetNews(query);

            if(news == null)
            {
                return NotFound();
            }
            
            return Ok(news);
        }

        [HttpGet("trending")]
        public async Task<IActionResult> GetTrendingStock()
        {
            var trending = await _marketNewsService.GetTrending();

            if(trending == null)
            {
                return NotFound();
            }

            return Ok(trending);
        }
    }
}
