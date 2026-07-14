using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PescaderiaApi.Models;

namespace PescaderiaApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Product mappings
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");

                // Store primitive string lists as JSON in SQL Server using converters
                entity.Property(p => p.Images).HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions)null!),
                    v => System.Text.Json.JsonSerializer.Deserialize<List<string>>(v, (System.Text.Json.JsonSerializerOptions)null!) ?? new List<string>()
                );

                entity.Property(p => p.Ingredients).HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions)null!),
                    v => System.Text.Json.JsonSerializer.Deserialize<List<string>>(v, (System.Text.Json.JsonSerializerOptions)null!) ?? new List<string>()
                );

                // Store NutritionInfo as a JSON column
                entity.OwnsOne(p => p.Nutrition, n =>
                {
                    n.ToJson();
                });
            });

            // Configure Order mappings
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Subtotal).HasColumnType("decimal(18,2)");
                entity.Property(o => o.Tax).HasColumnType("decimal(18,2)");
                entity.Property(o => o.Shipping).HasColumnType("decimal(18,2)");
                entity.Property(o => o.Total).HasColumnType("decimal(18,2)");

                // Store list of OrderItems as a JSON column
                entity.OwnsMany(o => o.Items, i =>
                {
                    i.ToJson();
                    i.Property(item => item.Price).HasColumnType("decimal(18,2)");
                });
            });

            // Configure Review mappings
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(r => r.Id);
            });

            // Configure User mappings
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
            });
        }
    }
}
