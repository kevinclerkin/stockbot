using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace StockBotAPI.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetUser(this ClaimsPrincipal user)
        {
            return user.Claims.SingleOrDefault(x => x.Type.Equals("https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims"))!.Value;
        }
    }
}
