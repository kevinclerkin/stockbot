using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.Data;
using StockBotAPI.DTO;
using StockBotAPI.Interfaces;
using StockBotAPI.Mappers;

namespace StockBotAPI.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepo;
        public StockController(IStockRepository stockRepo)
        {
           

            _stockRepo = stockRepo;
            
        }

        [HttpGet]

        public async Task<IActionResult> GetStockAsync()
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDTO stockDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = stockDto.ToStockFromCreateDTO();

            await _stockRepo.CreateStockAsync(stockModel);

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDTO());
        }
    }
}
