using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockBotAPI.DTO;
using StockBotAPI.Interfaces;
using StockBotAPI.Models;

namespace StockBotAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly ITokenService _tokenService;

        private readonly SignInManager<AppUser> _signInManager;
        public AppUserController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;

            _tokenService = tokenService;
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
                        return Ok(
                            new NewUserDTO
                            {
                                UserName = appUser.UserName, 
                                
                                Email = appUser.Email,

                                Token = _tokenService.CreateToken(appUser)

                            }
                        );
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var loggedUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName ==  loginDTO.UserName.ToLower());

            if(loggedUser == null)
            {
                return Unauthorized();
            }

            var userSignIn = await _signInManager.CheckPasswordSignInAsync(loggedUser, loginDTO.Password, false);

            if (!userSignIn.Succeeded)
            {
                return Unauthorized("Username or password is incorrect!");
            }

            return Ok(
                new NewUserDTO
                {
                    UserName = loggedUser.UserName,
                    Email = loggedUser.Email,
                    Token = _tokenService.CreateToken(loggedUser)
                });
        }
       
    }
}
