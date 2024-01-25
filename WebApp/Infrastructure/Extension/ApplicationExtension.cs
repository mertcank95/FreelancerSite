using Entities.Enum;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;

namespace WebApp.Infrastructure.Extension
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

        }


        public static async void ConfigureAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin-1234";
            const string adminEmail = "admin@admin.com";

            UserManager<User> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<User>>();
         
            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices
                .CreateAsyncScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            User user = await userManager.FindByEmailAsync(adminEmail);
            if (user is null)
            {
                user = new User()
                {
                    Email = adminEmail,
                    PhoneNumber = "0000000",
                    UserName = adminUser,
                    EmailConfirmed = true,
                    Company=null
                };
                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                {
                    Console.Write("Admin User could not created.");
                }

                List<string> rolesToAdd = new List<string>
                {
                    "Admin",
                };
                var adminRoleExists = await roleManager.RoleExistsAsync(Role.Admin.ToString().ToUpper());
                if(adminRoleExists)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, Role.Admin.ToString().ToUpper());

                    if (!roleResult.Succeeded)
                    {
                        Console.Write("System have problems with role defination");
                    }

                }

            }


        }


        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                    .AddSupportedCultures("tr-TR")
                    .SetDefaultCulture("tr-TR");
            });
        }




    }


}
