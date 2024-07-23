namespace StockBotAPI.DTO.NewsDTOs
{
    public class StockNewsDTO
    {
        public MetaDTO Meta { get; set; }
        public List<ArticleDTO> Data { get; set; }
    }
}
