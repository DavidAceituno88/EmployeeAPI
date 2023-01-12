using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Models;

public partial class DbemployeesContext : DbContext
{
    public DbemployeesContext()
    {
    }

    public DbemployeesContext(DbContextOptions<DbemployeesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PK__EMPLOYEE__51C8DD7A48756FC5");

            entity.ToTable("EMPLOYEE");

            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdPosition)
                .HasConstraintName("FK_Position");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition).HasName("PK__POSITION__DF67EA4C67FA5969");

            entity.ToTable("POSITION");

            entity.Property(e => e.PositionDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
