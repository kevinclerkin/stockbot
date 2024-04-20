using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Data;
using StockBotAPI.Interfaces;

namespace StockBotAPI.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDbContext context, IStockRepository stockRepo)
        {
            _context = context;

            _stockRepo = stockRepo;
            
        }

        [HttpGet]

        public async Task<IActionResult> GetAsync()
        {
            var stockList = await _stockRepo.GetAsync();
            
            return Ok(stockList);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock);

        }
    }
}
