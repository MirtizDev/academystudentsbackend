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
            public class UsersController:ControllerBase
    {   
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public UsersController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

        [HttpGet]
        [Route("getusers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet]
        [Route("getuser")]
        public async Task<IActionResult> GetUser()
        {
            var loggedInAcc = await _userManager.GetUserAsync(User);
            return Ok(loggedInAcc);
        }
    }
}