using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace surfs_up_api.Models
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            // Check if the Admin role exists, if not, create it
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                // Create the Admin role
                var role = new IdentityRole("Admin");
                await roleManager.CreateAsync(role);
            }

            // Check if the default admin user exists
            var adminUser = await userManager.FindByEmailAsync("admin@admin.com");

            if (adminUser == null)
            {
                // Create a default admin user
                var user = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin St",
                    ZipCode = "12345",
                    City = "AdminCity"
                };

                var result = await userManager.CreateAsync(user, "Admin@123"); // Create user with password

                // If user creation is successful, assign the Admin role
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}