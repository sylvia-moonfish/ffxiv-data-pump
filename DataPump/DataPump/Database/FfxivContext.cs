using DataPump.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DataPump.Database
{
    public class FfxivContext : DbContext
    {
        public DbSet<ItemModel> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql($"Host={Program.DatabaseHost};Database={Program.DatabaseName};Username={Program.DatabaseUsername};Password={Program.DatabasePassword};")
                .UseSnakeCaseNamingConvention();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder
                .UseIdentityAlwaysColumns()
                .Entity<ItemModel>()
                    .HasIndex(item => item.Key)
                    .IncludeProperties(item => item.RowKey);
    }
}
