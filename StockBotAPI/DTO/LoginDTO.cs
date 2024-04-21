using System.ComponentModel.DataAnnotations;

namespace StockBotAPI.DTO
{
    public class LoginDTO
    {
        [Required]

        public string? UserName { get; set; }

        [Required]
        
        public string? Password { get; set; }
    }
}
