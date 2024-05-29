using JobFinder.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace JobFinder.Persistence.Data;

public class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        string[] roleNames = { "Admin", "Employee", "Employer" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var admin = new ApplicationUser
        {
            UserName = "admin@admin.com",
            Email = "admin@admin.com"
        };

        string adminPassword = "Admin@123";
        var user = await userManager.FindByEmailAsync(admin.Email);

        if (user == null)
        {
            var createAdmin = await userManager.CreateAsync(admin, adminPassword);
            if (createAdmin.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }

}