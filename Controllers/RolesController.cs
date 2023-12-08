using academystudentsbackend.Models;
using academystudentsbackend.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace academystudentsbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController:ControllerBase
    {   
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public RolesController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

        [HttpGet]
        [Route("getrole")]
        [Authorize]
        public async Task<IActionResult> GetRole()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            var role = await _userManager.GetRolesAsync(user);  
            return Ok(role);
        }
    }
}