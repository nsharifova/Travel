
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class TravelDbContext:IdentityDbContext<IdentityUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelProDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        DbSet<Slider> Sliders { get; set; }
        DbSet<Hotel> Hotels { get; set; }
        DbSet<Promo> Promoses { get; set; }

        public DbSet<MyUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MyUser>().ToTable("Users");
            builder.Entity<IdentityUser>().ToTable("Users");
        }

    }
}
