using StockBotAPI.DTO;
using StockBotAPI.Models;

namespace StockBotAPI.Mappers
{
    public static class StockMapper
    {
        public static StockDTO ToStockDTO(this Stock stock)
        {

            return new StockDTO
            {
                Id = stock.Id,

                Symbol = stock.Symbol,

                CompanyName = stock.CompanyName,

                Purchase = stock.Purchase,

                LastDiv = stock.LastDiv,

                Industry = stock.Industry,

                MarketCap = stock.MarketCap

            };

        }

        public static Stock ToStockFromCreateDTO(this CreateStockDTO stockDTO)
        {
            return new Stock
            {
                Symbol = stockDTO.Symbol,
                CompanyName = stockDTO.CompanyName,
                Purchase = stockDTO.Purchase,
                LastDiv = stockDTO.LastDiv,
                Industry = stockDTO.Industry,
                MarketCap = stockDTO.MarketCap
            };
        }
    }
}
