using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PolicyAPI.Contexts
{
    public class PolicyIdentityContext:IdentityDbContext
    {

        public PolicyIdentityContext(DbContextOptions options):base(options) { 

            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
