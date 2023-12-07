using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using academystudentsbackend.Models;
using academystudentsbackend.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace academystudentsbackend.Controllers
{   
    [ApiController]
    [Route("api/account")]
    public class AccountController:ControllerBase
    {   
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IConfiguration _configruation;

    public AccountController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager,SignInManager<AppUser> signInManager,IConfiguration configuration)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _signInManager = signInManager;
        _configruation = configuration;
    }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                return BadRequest(new {message="email hatali"});
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user,model.Password,true);

            if(result.Succeeded)
            {
                return Ok(
                    new {token=GenerateJWT(user)}
                );
            }
            return Unauthorized();
        } 

        private object GenerateJWT(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configruation.GetSection("AppSettings:Secret").Value ?? "");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName ?? "")
            };

            var identity = new ClaimsIdentity(claims, "custom");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires=DateTime.UtcNow.AddDays(1),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser {
                    FullName = model.FullName,
                    UserName = model.UserName,
                    Email = model.Email,
                };
                IdentityResult result = await _userManager.CreateAsync(user,model.Password);
                if(result.Succeeded)
                {
                    return Ok();
                }
            }
            return RedirectToAction("Login");
        } 

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}