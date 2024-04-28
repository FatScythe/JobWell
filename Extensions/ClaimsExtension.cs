using server.Dto.Account;
using System.Security.Claims;

namespace server.Extensions
{
    public static class ClaimsExtension
    {
        public static CurrentUserDto GetCurrentUserInfo(this ClaimsPrincipal principal)
        {
            var id = principal.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's Id
            var name = principal.FindFirstValue(ClaimTypes.Name); // will give the user's name
            var role = principal.FindFirst(ClaimTypes.Role).Value; // will give user role
            var email = principal.FindFirstValue(ClaimTypes.Email); // will give the user's Email

            return new CurrentUserDto()
            {
                Id = id,
                Name = name,
                Role = role,
                Email = email,
            };
        }
    }
}
