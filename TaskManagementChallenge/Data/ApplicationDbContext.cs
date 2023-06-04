using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementChallenge.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        // add users and tasks dbset properties
        public DbSet<Entities.Tasks> Tasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        

    }
}