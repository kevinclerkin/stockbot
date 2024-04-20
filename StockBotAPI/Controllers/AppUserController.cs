using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockBotAPI.DTO;
using StockBotAPI.Models;

namespace StockBotAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public AppUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = register.Username,

                    Email = register.Email,
                };

                var registeredUser = await _userManager.CreateAsync(appUser, register.Password);

                if (registeredUser.Succeeded)
                {
                    var assignedRole = await _userManager.AddToRoleAsync(appUser, "User");
                    
                    if (assignedRole.Succeeded)
                    {
                        return Ok("User Registered");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return StatusCode(500, registeredUser);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, 0);

            }
        }
    }
}
