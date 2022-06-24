using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Велосмастерская.Model
{
    public partial class BikeShopContext : DbContext
    {
        public BikeShopContext()
        {
        }

        public BikeShopContext(DbContextOptions<BikeShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bicycle> Bicycles { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Clothe> Clothes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Scooter> Scooters { get; set; } = null!;
        public virtual DbSet<SparePart> SpareParts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAB4-16\\SQLEXPRESS;Database=BikeShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bicycle>(entity =>
            {
                entity.ToTable("Bicycle");

                entity.Property(e => e.Color).HasColumnType("ntext");

                entity.Property(e => e.CountryOfOrigin).HasColumnType("ntext");

                entity.Property(e => e.FactoryPrice)
                    .HasColumnType("money")
                    .HasColumnName("Factory price");

                entity.Property(e => e.Material).HasColumnType("ntext");

                entity.Property(e => e.Model).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NumberOfGears).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Type).HasColumnType("ntext");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Clothe>(entity =>
            {
                entity.ToTable("Clothe");

                entity.Property(e => e.BicycleShoes).HasMaxLength(50);

                entity.Property(e => e.BikeBikes).HasMaxLength(50);

                entity.Property(e => e.Gloves).HasMaxLength(50);

                entity.HasOne(d => d.Bicycle)
                    .WithMany(p => p.Clothes)
                    .HasForeignKey(d => d.BicycleId)
                    .HasConstraintName("FK_Clothes_Bicycle");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Discount)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Bicycle)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BicycleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Bicycle");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Order_Сlient");
            });

            modelBuilder.Entity<Scooter>(entity =>
            {
                entity.ToTable("Scooter");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Scooters)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Scooters_Сlient");
            });

            modelBuilder.Entity<SparePart>(entity =>
            {
                entity.ToTable("SparePart");

                entity.Property(e => e.Brakes).HasMaxLength(50);

                entity.Property(e => e.Chains).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Saddles).HasMaxLength(50);

                entity.HasOne(d => d.Bicycle)
                    .WithMany(p => p.SpareParts)
                    .HasForeignKey(d => d.BicycleId)
                    .HasConstraintName("FK_SpareParts_Bicycle");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
