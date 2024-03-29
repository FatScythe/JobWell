using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using server.Dto.Account;
using server.Extensions;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("/")]
    public class AuthController: ControllerBase
    {
        private readonly SignInManager<Account> _signInManager;
        private readonly UserManager<Account> _userManager;
        public AuthController(SignInManager<Account> signInManager, UserManager<Account> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("api/v1/auth/register")]
        public async Task<ActionResult> RegisterAccount([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (registerDto is null)
                    return BadRequest(new { success = false, message = "Please provide fields" });

                if (!ModelState.IsValid)
                    return BadRequest(new { success = false, message = "Please fill all fields", error = ModelState });

                var account = new Account
                {
                    UserName = registerDto.Email,
                    Name = registerDto.Name,
                    Email = registerDto.Email,
                };

                var createdUser = await _userManager.CreateAsync(account, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(account, registerDto.isEmployer ? "Employer" : "Employee");

                    if (roleResult.Succeeded)
                    {
                        return Ok(new { success = true, name = account.Name, email = account.Email });
                    }
                    else
                    {
                        return StatusCode(500, new { success = false, error = roleResult.Errors });
                    }
                }
                else
                {
                    return StatusCode(500, new { success = false, error = createdUser.Errors });
                }
            } catch(Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet, Authorize]
        [Route("/api/v1/user/showMe")]

        public ActionResult GetCurrentUserInfo()
        {
            var user = User.GetCurrentUserInfo();

            return Ok(new {success = true, user});
        }

        [HttpPost]
        [Route("logout")]

        public async Task<ActionResult> LogoutAccount([FromForm] object empty)
        {
            if (empty != null)
            {
                await _signInManager.SignOutAsync();
                return Ok(new { success = true, message = "Logout successful" });
            }
            return Unauthorized(new { success = false, message = "Logout failed" });
        }
    }
}
