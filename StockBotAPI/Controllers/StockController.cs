using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Data;

namespace StockBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        [HttpGet]

        public IActionResult Get()
        {
            var stockList = _context.Stocks.ToList();
            
            return Ok(stockList);
        }
    }
}
