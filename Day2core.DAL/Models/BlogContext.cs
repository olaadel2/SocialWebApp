using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Day2core.DAL.Models
{
    public class BlogContext: IdentityDbContext<ApplicationUser>
    {
        internal object userofgroup;

        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {
                
        }

        public virtual DbSet<blog> Blogs { get; set; }
        public virtual DbSet<post> Posts { get; set; }
        public virtual DbSet<group> Groups  { get; set; }
        public virtual DbSet<groupofuser> Groupofusers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<groupofuser>().HasKey(sc => new { sc.GroupId, sc.UserId });



        }
    }
}

