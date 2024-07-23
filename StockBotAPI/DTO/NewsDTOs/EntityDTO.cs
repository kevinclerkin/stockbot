namespace StockBotAPI.DTO.NewsDTOs
{
    public class EntityDTO
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string Industry { get; set; }
        public double MatchScore { get; set; }
        public double SentimentScore { get; set; }
        public List<HighlightDTO> Highlights { get; set; }
    }
}
