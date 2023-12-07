using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace academystudentsbackend.Models
{   
    public class AppUser:IdentityUser<int>
    {
        public string FullName { get; set; } = null!;

    }
}