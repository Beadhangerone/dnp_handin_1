
using h1.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace h1.Helpers
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().Property(e => e.Id).ValueGeneratedOnAdd();
            //builder.Entity<User>().HasKey(u => u.Id);
            /*
             builder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@test.com",
                    Password = "test"
                }
            );
            */

            Console.WriteLine("156543565456456456 Initialized user");
        }
    }
}
