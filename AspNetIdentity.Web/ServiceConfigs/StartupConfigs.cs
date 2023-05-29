using System;
using AspNetIdentity.Web.Models;

namespace AspNetIdentity.Web.ServiceConfigs
{
    public static class StartupCofnfigs
    {
        public static void AddIdentityOpt(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;


                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 3;

            }).AddEntityFrameworkStores<AppDbContext>();
        }

        public static void AddMapRoutesToApp(this IEndpointRouteBuilder app)
        {
            app.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}

