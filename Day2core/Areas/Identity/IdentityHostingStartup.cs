using System;
using Day2core.Areas.Identity.Data;
using Day2core.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Day2core.Areas.Identity.IdentityHostingStartup))]
namespace Day2core.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Day2coreContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("blogcon")));

                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<Day2coreContext>();
                //services.AddIdentity<ApplicationUser, IdentityRole>()
                //.AddEntityFrameworkStores<Day2coreContext>()
                //.AddDefaultUI()
                //.AddDefaultTokenProviders();
            });
        }
    }
}