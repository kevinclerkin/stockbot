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

        [HttpGet("profile/{query}")]
        public async Task<IActionResult> CompanyProfile(string query)
        {
            var profiles = await _finPrepService.GetStockProfile(query);
            if (profiles == null)
            {
                return NotFound();
            }

            return Ok(profiles);
        }

        [HttpGet("overview/{query}")]
        public async Task<IActionResult> CompanyOverview(string query)
        {
            var profile = await _finPrepService.GetCompanyOverview(query);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        [HttpGet("key-metrics/{query}")]
        public async Task<IActionResult> CompanyMetrics(string query)
        {
            var metrics = await _finPrepService.GetKeyMetrics(query);
            if (metrics == null)
            {
                return NotFound();
            }

            return Ok(metrics);
        }

        [HttpGet("income/{query}")]
        public async Task<IActionResult> CompanyIncome(string query)
        {
            var income = await _finPrepService.GetIncomeStatement(query);
            if (income == null)
            {
                return NotFound();
            }

            return Ok(income);
        }
    }
}
