using Microsoft.EntityFrameworkCore;
using PolicyAPI.Models;

namespace PolicyAPI.Contexts
{
    public class PolicyContext:DbContext
    {
        public PolicyContext(DbContextOptions<PolicyContext> options) : base(options) { 
        
             Database.EnsureCreated();
        
        }

        public DbSet<PolicyHolder> PolicyHolders { get; set; }

        public DbSet<Policy> Policies { get; set; } 


    }
}
