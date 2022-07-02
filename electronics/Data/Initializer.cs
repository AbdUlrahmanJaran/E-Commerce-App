using Electronics.Auth.Model;
using Electronics.Data.Static;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Electronics.Data
{
    public class Initializer
    {

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(Roles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                }

                if (!await roleManager.RoleExistsAsync(Roles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.User));
                }

                if (!await roleManager.RoleExistsAsync(Roles.Editor))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.Editor));
                }

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@electronics.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin123!");
                    await userManager.AddToRoleAsync(newAdminUser, Roles.Admin);
                }

                string editorUserEmail = "editor@electronics.com";

                var editorUser = await userManager.FindByEmailAsync(editorUserEmail);
                if (editorUser == null)
                {
                    var newEditorUser = new ApplicationUser()
                    {
                        FullName = "Editor User",
                        UserName = "editor-user",
                        Email = editorUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newEditorUser, "Editoruser123!");
                    await userManager.AddToRoleAsync(newEditorUser, Roles.Editor);
                }


                string appUserEmail = "user@electronics.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Appuser123!");
                    await userManager.AddToRoleAsync(newAppUser, Roles.User);
                }
            }
        }
    }
}
