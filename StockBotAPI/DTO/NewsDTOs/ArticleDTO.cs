namespace StockBotAPI.DTO.NewsDTOs
{
    public class ArticleDTO
    {
        public string Uuid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Snippet { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Language { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Source { get; set; }
        public List<EntityDTO> Entities { get; set; }
    }
}
