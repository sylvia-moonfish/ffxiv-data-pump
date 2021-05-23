using DataPump.Memory.Models;
using Microsoft.EntityFrameworkCore;

namespace DataPump.Memory
{
    public class MemoryContext : DbContext
    {
        public DbSet<BaseParamModel> BaseParams { get; set; }
        public DbSet<ClassJobCategoryModel> ClassJobCategories { get; set; }
        public DbSet<EquipSlotCategoryModel> EquipSlotCategories { get; set; }
        public DbSet<ItemModel> Foods { get; set; }
        public DbSet<ItemModel> Materias { get; set; }
        public DbSet<ItemModel> Equipments { get; set; }
        public DbSet<ItemUICategoryModel> ItemUICategories { get; set; }
        public DbSet<ParameterValueModel> ParameterValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //=> optionsBuilder.UseSqlite("Filename=:memory:");
            => optionsBuilder.UseSqlite("Filename=Test.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseParamModel>().HasIndex(baseParam => baseParam.Key).IncludeProperties(baseParam => baseParam.RowKey);
            modelBuilder.Entity<ClassJobCategoryModel>().HasIndex(classJobCategory => classJobCategory.Key).IncludeProperties(classJobCategory => classJobCategory.RowKey);
            modelBuilder.Entity<EquipSlotCategoryModel>().HasIndex(equipSlotCategory => equipSlotCategory.Key).IncludeProperties(equipSlotCategory => equipSlotCategory.RowKey);
            modelBuilder.Entity<ItemModel>().HasIndex(item => item.Key).IncludeProperties(item => item.RowKey);
            modelBuilder.Entity<ItemUICategoryModel>().HasIndex(itemUICategory => itemUICategory.Key).IncludeProperties(itemUICategory => itemUICategory.RowKey);
        }
    }
}
