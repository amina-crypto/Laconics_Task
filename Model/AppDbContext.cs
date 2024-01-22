using Microsoft.EntityFrameworkCore;

namespace Laconics_Task.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }

}
