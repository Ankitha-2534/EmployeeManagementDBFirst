using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DomainModelLayer.Models;

public partial class EmployeeManagementContext : DbContext
{
    public EmployeeManagementContext()
    {
    }

    public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.0.0.27;Database=EmployeeManagement;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07CB6C97D5");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07FFEEF148");

            entity.HasIndex(e => e.Uid, "UQ__Employee__C5B69A4BA47088B0").IsUnique();

            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.JoinDate).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Uid)
                .HasMaxLength(6)
                .IsUnicode(false);

            entity.HasOne(d => d.Manager).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__Employees__Manag__571DF1D5");

            entity.HasOne(d => d.Project).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Employees__Proje__5812160E");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Employees__RoleI__5629CD9C");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC07CCD0A9E2");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Managers__3214EC07416E6B6A");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Projects__3214EC0747302E8B");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A4048D755");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Roles)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Roles__Departmen__5165187F");

            entity.HasOne(d => d.Location).WithMany(p => p.Roles)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__Roles__LocationI__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
