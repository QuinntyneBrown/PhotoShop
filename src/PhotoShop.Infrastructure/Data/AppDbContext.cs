using PhotoShop.Core.Interfaces;
using PhotoShop.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace PhotoShop.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Snapshot> Snapshots { get; set; }
        public DbSet<StoredEvent> StoredEvents { get; set; }
    }
}
