using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LinqEFProject
{
    public partial class EFModel : DbContext
    {
        public EFModel()
            : base("name=EFModel")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ImportItem> ImportItems { get; set; }
        public virtual DbSet<ImportPermission> ImportPermissions { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemUnit> ItemUnits { get; set; }
        public virtual DbSet<RequestItem> RequestItems { get; set; }
        public virtual DbSet<RequestPermission> RequestPermissions { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.RequestPermissions)
                .WithOptional(e => e.Client)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Stores)
                .WithMany(e => e.Items)
                .Map(m => m.ToTable("StoreItems").MapLeftKey("ItemCode").MapRightKey("StoreId"));

            modelBuilder.Entity<Store>()
                .HasMany(e => e.ImportPermissions)
                .WithOptional(e => e.Store)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Store>()
                .HasMany(e => e.RequestPermissions)
                .WithOptional(e => e.Store)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.ImportPermissions)
                .WithOptional(e => e.Supplier)
                .WillCascadeOnDelete();
        }
    }
}
