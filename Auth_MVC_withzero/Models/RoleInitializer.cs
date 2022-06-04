using MVC_CollegeManagement.Models;  // namespace of the User model
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MVC_CollegeManagement
{
    public class RoleInitializer
    {
        /*The InitializeAsync() method, which adds two roles to the database - "admin" and "user", 
        as well as one administrator user.To add here, the methods of the User Manager and 
        Role Manager classes are used, which are available to us through the collection of 
        application services.*/
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "user1@gmail.com";
            string adminpassword = "123456";
            string profEmail = "user2@gmail.com";
            string profpassword = "123456";
            string studEmail = "user3@gmail.com";
            string studpassword = "123456";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("professor") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("professor"));
            }
            if (await roleManager.FindByNameAsync("student") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("student"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, adminpassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
            if (await userManager.FindByNameAsync(profEmail) == null)
            {
                User prof = new User { Email = profEmail, UserName = profEmail };
                IdentityResult result = await userManager.CreateAsync(prof, profpassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(prof, "professor");
                }
            }
            if (await userManager.FindByNameAsync(studEmail) == null)
            {
                User stud = new User { Email = studEmail, UserName = studEmail };
                IdentityResult result = await userManager.CreateAsync(stud, studpassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(stud, "student");
                }
            }
        }
    }
}
