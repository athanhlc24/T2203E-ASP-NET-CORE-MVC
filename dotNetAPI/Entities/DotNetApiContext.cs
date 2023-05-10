using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotNetAPI.Entities;

public partial class DotNetApiContext : DbContext
{
    public DotNetApiContext()
    {
    }

    public DotNetApiContext(DbContextOptions<DotNetApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS_THANH;Initial Catalog=dotNetAPI;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__brands__3213E83FD97FEA53");

            entity.ToTable("brands");

            entity.HasIndex(e => e.Name, "UQ__brands__72E12F1BBC2CE0A2").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__carts__3213E83F0FF6F421");

            entity.ToTable("carts");

            entity.HasIndex(e => e.Email, "UQ__carts__AB6E6164E73F54DF").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Qty)
                .HasDefaultValueSql("((1))")
                .HasColumnName("qty");
            entity.Property(e => e.UsersId).HasColumnName("users_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__carts__product_i__36B12243");

            entity.HasOne(d => d.Users).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__carts__users_id__35BCFE0A");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83FCD158518");

            entity.ToTable("categories");

            entity.HasIndex(e => e.Name, "UQ__categori__72E12F1B75139D99").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3213E83F55734254");

            entity.ToTable("products");

            entity.HasIndex(e => e.Name, "UQ__products__72E12F1B94B38AC3").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(12, 4)")
                .HasColumnName("price");
            entity.Property(e => e.Qty)
                .HasDefaultValueSql("((1))")
                .HasColumnName("qty");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("thumbnail");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__products__brand___2E1BDC42");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__products__catego__2A4B4B5E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F6C053B57");

            entity.ToTable("users");

            entity.HasIndex(e => e.Name, "UQ__users__72E12F1BFB263206").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__users__AB6E61644581D864").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
