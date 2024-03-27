using System.Security.Claims;

namespace server.Extensions
{
    public static class ClaimsExtension
    {
        public static object GetCurrentUserInfo(this ClaimsPrincipal principal)
        {
            var role = principal.FindFirst(ClaimTypes.Role); // will give user Id
            var name = principal.FindFirstValue(ClaimTypes.Name); // will give the user's userName
            var email = principal.FindFirstValue(ClaimTypes.Email); // will give the user's Email

            return new { name, role, email};
        }
    }
}
