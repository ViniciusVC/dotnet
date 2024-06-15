using unit_testing_dotnetcore.Entities;
using Microsoft.EntityFrameworkCore;

namespace unit_testing_dotnetcore.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
