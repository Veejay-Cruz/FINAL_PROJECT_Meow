using FINAL_PROJECT_Meow.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FINAL_PROJECT_Meow.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var roleName in SystemRoles.AllRoles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public static async Task InitializeAdminUser(UserManager<ApplicationUser> userManager)
        {
            const string adminEmail = "admin@meow.com";
            const string adminPassword = "Admin@123456";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "System",
                    LastName = "Administrator",
                    MiddleName = "Admin",
                    Address = "System Address", 
                    PhoneNumber = "00000000", 
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, SystemRoles.Admin);
                }
            }
        }
    }
}