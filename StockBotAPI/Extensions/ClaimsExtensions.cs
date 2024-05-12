using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace StockBotAPI.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetUser(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            
            else
            {
               return user.Claims.SingleOrDefault(x => x.Type.Equals("name"))!.Value;
                
           
            }
        }
    }
}



