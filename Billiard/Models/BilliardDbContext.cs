using Microsoft.EntityFrameworkCore;
using Billiard.Models;

namespace Billiard.Models
{
    public class BilliardDbContext:DbContext
    {
        public BilliardDbContext(DbContextOptions<BilliardDbContext> options) : base(options)
        {

        }

        public DbSet<BilliardTables> Billiards { get; set; }

        public DbSet<Billiard.Models.Reservations> Reservations { get; set; }

        public DbSet<Billiard.Models.Users> Users { get; set; }
    }
}
