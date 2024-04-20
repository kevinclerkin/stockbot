﻿using StockBotAPI.Models;

namespace StockBotAPI.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAsync();

        Task<Stock?> GetByIdAsync(int id);
    }
}