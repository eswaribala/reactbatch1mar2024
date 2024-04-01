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
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PolicyHolder>()
                .Property(p => p.Gender)
                .HasConversion<string>()
                .HasMaxLength(20);
        }
    }
}
