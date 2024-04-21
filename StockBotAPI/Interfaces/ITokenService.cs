using StockBotAPI.Models;

namespace StockBotAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
