using System;
using AspNetIdentity.Web.Models;

namespace AspNetIdentity.Web.ServiceConfigs
{
    public static class StartupCofnfigs
    {
        // Identity Options
        public static void AddIdentityOpt(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;


                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 3;

            }).AddEntityFrameworkStores<AppDbContext>();
        }
        // Route Options
        public static void AddMapRoutesToApp(this IEndpointRouteBuilder app)
        {
            app.MapControllerRoute(
              name: "areas",    
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
        // Cookie Options
        public static void SetCookieOptions(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(opt =>
            {
                var cookieBuilder = new CookieBuilder();
                cookieBuilder.Name = "GorkeuAppCookie";

                opt.LoginPath = new PathString("/Home/Signin");
                opt.LogoutPath = new PathString("/Member/Signout");
                opt.Cookie = cookieBuilder;
                opt.ExpireTimeSpan = TimeSpan.FromDays(60);
                opt.SlidingExpiration = true;

            });
        }
    }
}

