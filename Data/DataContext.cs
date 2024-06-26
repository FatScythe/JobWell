﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class DataContext: IdentityDbContext<Account>
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        { 
        
        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Job> Jobs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>() 
            {
                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Name = "Employee",
                    NormalizedName =  "EMPLOYEE"
                }, 
                new IdentityRole()
                {
                    Name = "Employer",
                    NormalizedName = "EMPLOYER",
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
