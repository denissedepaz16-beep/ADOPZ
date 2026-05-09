using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ADOPZ.DataAccess;

public partial class BoutiqueModaContext : DbContext
{
    private DbSet<User> users;

    public BoutiqueModaContext()
    {
    }

    public BoutiqueModaContext(DbContextOptions<BoutiqueModaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Designer> Designers { get; set; }

    public virtual DbSet<Garment> Garments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get => users; set => users = value; }

    protected override void Configuring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=BoutiqueModa;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Designer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Designer__3214EC0705972706");

            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Garment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Garments__3214EC07DA2E9D1A");

            entity.Property(e => e.MarketPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Designer).WithMany(p => p.Garments)
                .HasForeignKey(d => d.DesignerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Garments__Design__5165187F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC075A57BD74");

            entity.Property(e => e.PositionName)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07B6A9BAA2");

            entity.Property(e => e.Handle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecretHash).IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
