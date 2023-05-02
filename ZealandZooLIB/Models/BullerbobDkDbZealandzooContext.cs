using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ZealandZooLIB.Models;

public partial class BullerbobDkDbZealandzooContext : DbContext
{
    public BullerbobDkDbZealandzooContext()
    {
    }

    public BullerbobDkDbZealandzooContext(DbContextOptions<BullerbobDkDbZealandzooContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bullet> Bullets { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    public virtual DbSet<Newsletter> Newsletters { get; set; }

    public virtual DbSet<StorageItem> StorageItems { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(Secret.GetSecret());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bullet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bullet__3214EC07A7D2691C");

            entity.ToTable("Bullet");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ContentBullet)
                .HasMaxLength(3999)
                .HasColumnName("Content_Bullet");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0781AF8567");

            entity.ToTable("Event");

            entity.Property(e => e.DateFrom)
                .HasColumnType("datetime")
                .HasColumnName("Date_From");
            entity.Property(e => e.DateTo)
                .HasColumnType("datetime")
                .HasColumnName("Date_To");
            entity.Property(e => e.MaxGuest).HasColumnName("Max_Guest");
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.HasKey(e => e.Type).HasName("PK__tmp_ms_x__F9B8A48A2ABB4DC2");

            entity.ToTable("ItemType");

            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<Newsletter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Newslett__3214EC0711AC90DD");

            entity.ToTable("Newsletter");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Content)
                .HasMaxLength(4000)
                .IsFixedLength();
        });

        modelBuilder.Entity<StorageItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StorageI__3214EC07D429859D");

            entity.ToTable("StorageItem");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsFixedLength();

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.StorageItems)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StorageItem_ItemType");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07FFF7130C");

            entity.ToTable("Student");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("Last_Name");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
