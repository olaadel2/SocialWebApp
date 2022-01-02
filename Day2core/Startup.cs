using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Day2core.DAL.Models;
using Day2core.Repository;
using Day2core.Areas;
using Day2core.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using ReflectionIT.Mvc.Paging;

namespace Day2core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<Day2coreContext>(option => option.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("blogcon")));
            services.AddControllersWithViews();
            services.AddScoped<IplogRepository, plogRepository>();
            //services.AddScoped<postlistrespoditory, postlistrespoditory>();
            //services.AddScoped<postrepository, postrepository>();
           services.AddScoped<IpostRepository,postrepository>();
            services.AddScoped<IgroupRepository, grouprepository>();
            services.AddScoped<grouprepository, grouprepository>();
            services.AddScoped<groupofuserrepository, groupofuserrepository>();
            services.AddAutoMapper(typeof(Startup));
            services.AddRazorPages();
            // services.AddIdentity<ApplicationUser, IdentityRole>()
            //.AddEntityFrameworkStores<Day2coreContext>()
            //.AddDefaultUI()
            //.AddDefaultTokenProviders();
            services.AddDbContext<Day2coreContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("blogcon")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<Day2coreContext>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<Day2coreContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
          
        }
        
    }
}
