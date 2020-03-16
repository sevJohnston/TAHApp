using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TakeAHike.Models;
using TakeAHike.Repositories;
using System;

namespace TakeAHike
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        
        public Startup(IConfiguration configuration ) =>       
            Configuration = configuration;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services, IWebHostEnvironment env)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

                //This will tell the browser to prevent transmission of a cookie over an unencrypted HTTP request
                options.Secure = CookieSecurePolicy.Always;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //services.AddMvc();

            // Inject our repositories into our controllers
            //need to uncomment line below for using actual HikeRepository--not testing
            services.AddTransient<IHikeRepository, HikeRepository>();

            //need to uncomment line below for testing
            //services.AddTransient<IHikeRepository, FakeHikeRepository>();

            //specify DbContext and ConnectionString         
            if (env.IsDevelopment())
            {
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                    Configuration["ConnectionStrings:MsSqlConnection"]));
            }

            else if (env.IsProduction())
            {
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                    Configuration["ConnectionStrings:Azure"]));
            }

            //add identity method
            services.AddIdentity<AppUser, IdentityRole>(opts =>
            {
                //outlines requirements for passwords
                opts.User.RequireUniqueEmail = true;
                //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })

                //.AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            //supports response caching
            services.AddResponseCaching();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                   
            }
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}");
                endpoints.MapRazorPages();
            });
            
        }
    }
}
