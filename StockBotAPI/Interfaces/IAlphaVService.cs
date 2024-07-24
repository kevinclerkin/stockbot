namespace StockBotAPI.Interfaces
{
    public interface IAlphaVService
    {
        Task<Dictionary<string, dynamic>> GetTrendingNews(string symbol);

        Task<string> GetSentiment(string symbol);

    }
}
