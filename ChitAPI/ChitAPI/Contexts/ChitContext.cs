using ChitAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChitAPI.Contexts
{
    public class ChitContext:DbContext
    {
        public ChitContext(DbContextOptions<ChitContext> dbContextOptions) : base(dbContextOptions)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Chit> Chits { get; set; }
        public DbSet<ChitTransaction> ChitTransactions { get; set; }
    }
}
