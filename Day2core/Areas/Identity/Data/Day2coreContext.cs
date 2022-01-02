using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Day2core.Areas.Identity.Data
{
    public class Day2coreContext : IdentityDbContext<ApplicationUser>
    {
        public Day2coreContext(DbContextOptions<Day2coreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<blog> Blogs { get; set; }
        public virtual DbSet<post> Posts { get; set; }
        public virtual DbSet<group> Groups { get; set; }
        public virtual DbSet<groupofuser> Groupofusers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<groupofuser>().HasKey(sc => new { sc.GroupId, sc.UserId });
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
