using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("/")]
    public class AuthController: ControllerBase
    {
        private readonly SignInManager<Account> _signInManager;
        public AuthController(SignInManager<Account> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("logout")]

        public async Task<ActionResult> LogoutAccount([FromForm] object empty)
        {
            if (empty != null)
            {
                await _signInManager.SignOutAsync();
                return Ok(new { isSuccess = true, message = "Logout successful" });
            }
            return Unauthorized(new { isSuccess = false, message = "Logout failed" });
        }
    }
}
