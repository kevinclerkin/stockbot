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
            var stockNews = await _alphaVService.GetTrendingNews(query);
            if(stockNews == null)
            {
                return NotFound("No latest news found for this stock");
            }

            return Ok(stockNews);
        }

        [HttpGet("/sentiment{query}")]
        public async Task<IActionResult> GetSentiment(string query)
        {
            var sentiment = await _alphaVService.GetSentiment(query);

            if(sentiment == null)
            {
                return NotFound("No sentiment available");
            }

            return Ok(sentiment);
        }
    }
}

