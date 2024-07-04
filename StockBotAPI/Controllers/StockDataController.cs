using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Interfaces;

namespace StockBotAPI.Controllers
{
    [Route("api/stock-data")]
    [ApiController]
    public class StockDataController : ControllerBase
    {
        private readonly IFinPrepService _finPrepService;

        public StockDataController(IFinPrepService finPrepService)
        {
            _finPrepService = finPrepService;
        }

        [HttpGet("{query}")]
        public async Task<IActionResult> SearchCompany(string query)
        {
            var companies = await _finPrepService.GetStockBySymbol(query);
            if (companies == null)
            {
                return NotFound();
            }

            return Ok(companies);
        }
    }
}
