using Microsoft.EntityFrameworkCore;

namespace Billiard.Models
{
    public class BilliardDbContext:DbContext
    {
        public BilliardDbContext(DbContextOptions<BilliardDbContext> options) : base(options)
        {

        }

        public DbSet<BilliardTables> Billiards { get; set; }
    }
}
