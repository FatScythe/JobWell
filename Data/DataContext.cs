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


    }
}
