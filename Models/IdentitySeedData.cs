using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace academystudentsbackend.Models
{
    public class IdentityRoleSeedData
    {
        private const string roleName1 = "admin";
        private const string roleName2 = "student";

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

            var role1 = await roleManager.FindByNameAsync(roleName1);
            var role2 = await roleManager.FindByNameAsync(roleName2);

            var user = await userManager.FindByNameAsync(adminUser);

            if(role1 == null && role2 == null && adminUser == null)
            {
                role1 = new AppRole {
                    Name = roleName1
                };
                role2 = new AppRole {
                    Name = roleName2
                };
                user = new AppUser {
                    FullName = "Nüşabə Quliyeva",
                    UserName = adminUser,
                    Email = "admin@nusabequliyeva.com",
                };
                await userManager.CreateAsync(user,adminPassword);
                await roleManager.CreateAsync(role1);
                await roleManager.CreateAsync(role2);
            }
        }

    }
}