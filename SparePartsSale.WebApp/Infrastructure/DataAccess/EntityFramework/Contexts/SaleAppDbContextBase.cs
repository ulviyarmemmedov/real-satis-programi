using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.EntityFramework.Contexts
{
    public partial class SaleAppDbContextBase : DbContext
    {
        public SaleAppDbContextBase()
        {
        }

        public SaleAppDbContextBase(DbContextOptions<SaleAppDbContextBase> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<MenuPermission> MenuPermissions { get; set; } = null!;
        public virtual DbSet<Place> Places { get; set; } = null!;
        public virtual DbSet<PlaceShelf> PlaceShelves { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<SaleDetail> SaleDetails { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WarehouseDoc> WarehouseDocs { get; set; } = null!;
        public virtual DbSet<WarehouseDocDetail> WarehouseDocDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-5HFIHAD\\SQLEXPRESS;Initial Catalog=DB_SALE;Integrated Security=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("Card");

                entity.Property(e => e.Crdate).HasColumnType("datetime");

                entity.Property(e => e.Text).HasMaxLength(150);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Crdate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PlateNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Type).HasComment("0 Musteri;1 Vendor");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Icon)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuPermission>(entity =>
            {
                entity.ToTable("MenuPermission");

                entity.Property(e => e.Crdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("Place");

                entity.Property(e => e.Crdate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<PlaceShelf>(entity =>
            {
                entity.ToTable("PlaceShelf");

                entity.Property(e => e.Crdate).HasColumnType("datetime");

                entity.Property(e => e.ShelfBarcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShelfName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Crdate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StockCalculation).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.Property(e => e.Crdate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale");

                entity.Property(e => e.Crdate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PayType).HasComment("0-Nagd;1-Pos");
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.ToTable("SaleDetail");

                entity.Property(e => e.Crdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SurName).HasMaxLength(50);

                entity.Property(e => e.UserType).HasComment("0-Site;1-Admin");
            });

            modelBuilder.Entity<WarehouseDoc>(entity =>
            {
                entity.ToTable("WarehouseDoc");

                entity.Property(e => e.Crdate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WarehouseDocDetail>(entity =>
            {
                entity.ToTable("WarehouseDocDetail");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
