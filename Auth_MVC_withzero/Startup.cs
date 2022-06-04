using MVC_CollegeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SignalRApp;

namespace MVC_CollegeManagement
{
    public class Startup
    {
        /*Next, we need to change the Startup class to apply all the necessary 
        services to work with Identity and the database*/
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Adding a password validator service
            services.AddTransient<IPasswordValidator<User>,
                    CustomPasswordValidator>(serv => new CustomPasswordValidator(6));

            services.AddTransient<IUserValidator<User>, CustomUserValidator>();

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(opts => {
                opts.Password.RequiredLength = 5;   // minimum length
                opts.Password.RequireNonAlphanumeric = false;   // are non-alphanumeric characters required
                opts.Password.RequireLowercase = false; // are lowercase characters required
                opts.Password.RequireUppercase = false; // are uppercase characters required
                opts.Password.RequireDigit = false; // are numbers required
            })
    .AddEntityFrameworkStores<ApplicationContext>();

            services.AddControllersWithViews();

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    // enabling authentication
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}
