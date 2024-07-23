namespace StockBotAPI.Interfaces
{
    public interface IMarketNewsService
    {
        Task<string> GetNews(string symbol);
    }
}
