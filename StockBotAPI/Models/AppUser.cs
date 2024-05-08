using Microsoft.AspNetCore.Identity;

namespace StockBotAPI.Models
{
    public class AppUser : IdentityUser
    {
        public List<Portfolio> Portfolio { get; set; } = new List<Portfolio>();
    }
}
