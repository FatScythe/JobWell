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
        DbSet<Application> Applications { get; set; }
        DbSet<Job> Jobs { get; set; }


    }
}
