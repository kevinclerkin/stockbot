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
                var claim = user.Claims.SingleOrDefault(x => x.Type.Equals("given_name"));
                if (claim != null)
                {
                    return claim.Value;
                }
                else
                {
                    throw new InvalidOperationException("Given name claim not found.");
                }
            }
        }
    }
}
