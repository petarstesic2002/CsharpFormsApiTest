using System;
using System.Collections.Generic;
using DataAccessModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessModels;

public partial class TestDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-54K3IOI\\SQLEXPRESS;Initial Catalog=CsharpFormsApiTestDb;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.CategoryName, "CategoryName_Unique").IsUnique();

            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.ProductName, "ProductName_Unique").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasMany(d => d.Categories).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductCategories_Categories"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductCategories_Products"),
                    j =>
                    {
                        j.ToTable("ProductCategories");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
