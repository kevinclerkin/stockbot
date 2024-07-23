namespace StockBotAPI.DTO.NewsDTOs
{
    public class DataItemDTO
    {
        public string Key { get; set; }
        public int TotalDocuments { get; set; }
        public double SentimentAvg { get; set; }
        public double Score { get; set; }
    }
}
