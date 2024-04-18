using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Data;

namespace StockBotAPI.Controllers
{
    [Route("api/stock")]
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

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var stock = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock);

        }
    }
}
