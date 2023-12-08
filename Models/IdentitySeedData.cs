using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace academystudentsbackend.Models
{
    public class IdentitySeedData
    {
   
        private const string adminUser = "admin";
        private const string adminPassword = "Admin_123";
        public static async void IdentityTestRoles(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CourseContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            var roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();



            var user = await userManager.FindByNameAsync(adminUser);
            if(user == null)
            {
                user = new AppUser {
                    FullName = "Nüşabə Quliyeva",
                    UserName = adminUser,
                    Email = "admin@nusabequliyeva.com",
                };
                var role1 = await roleManager.CreateAsync(new AppRole {
                    Name="Admin"
                });
                var role2 = await roleManager.CreateAsync(new AppRole {
                    Name="Student"
                });
                await userManager.CreateAsync(user,adminPassword);
                await userManager.AddToRoleAsync(user,"Admin");
            }
        }

    }
}