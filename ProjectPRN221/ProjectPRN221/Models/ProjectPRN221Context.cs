using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ProjectPRN221.Models
{
    public partial class ProjectPRN221Context : DbContext
    {
        public ProjectPRN221Context()
        {
        }

        public ProjectPRN221Context(DbContextOptions<ProjectPRN221Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Input> Inputs { get; set; } = null!;
        public virtual DbSet<InputInfo> InputInfos { get; set; } = null!;
        public virtual DbSet<Object> Objects { get; set; } = null!;
        public virtual DbSet<Output> Outputs { get; set; } = null!;
        public virtual DbSet<OutputInfo> OutputInfos { get; set; } = null!;
        public virtual DbSet<Suplier> Supliers { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                       .SetBasePath(Directory.GetCurrentDirectory())
                                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.ContractDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<Input>(entity =>
            {
                entity.ToTable("Input");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.DateInput).HasColumnType("datetime");
            });

            modelBuilder.Entity<InputInfo>(entity =>
            {
                entity.ToTable("InputInfo");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.IdInput).HasMaxLength(128);

                entity.Property(e => e.IdObject).HasMaxLength(128);

                entity.Property(e => e.InputPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.OutputPrice).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdInputNavigation)
                    .WithMany(p => p.InputInfos)
                    .HasForeignKey(d => d.IdInput)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InputInfo__IdInp__37A5467C");

                entity.HasOne(d => d.IdObjectNavigation)
                    .WithMany(p => p.InputInfos)
                    .HasForeignKey(d => d.IdObject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InputInfo__IdObj__36B12243");
            });

            modelBuilder.Entity<Object>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Qrcode).HasColumnName("QRCode");

                entity.HasOne(d => d.IdSuplierNavigation)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.IdSuplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Objects__IdSupli__2B3F6F97");

                entity.HasOne(d => d.IdUnitNavigation)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.IdUnit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Objects__BarCode__2A4B4B5E");
            });

            modelBuilder.Entity<Output>(entity =>
            {
                entity.ToTable("Output");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.DateOutput).HasColumnType("datetime");
            });

            modelBuilder.Entity<OutputInfo>(entity =>
            {
                entity.ToTable("OutputInfo");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.IdInputInfo).HasMaxLength(128);

                entity.Property(e => e.IdObject).HasMaxLength(128);

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.OutputInfos)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OutputInf__IdCus__3D5E1FD2");

                entity.HasOne(d => d.IdInputInfoNavigation)
                    .WithMany(p => p.OutputInfos)
                    .HasForeignKey(d => d.IdInputInfo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OutputInf__IdInp__3E52440B");

                entity.HasOne(d => d.IdObjectNavigation)
                    .WithMany(p => p.OutputInfos)
                    .HasForeignKey(d => d.IdObject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OutputInf__IdObj__3C69FB99");
            });

            modelBuilder.Entity<Suplier>(entity =>
            {
                entity.ToTable("Suplier");

                entity.Property(e => e.ContractDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__IdRole__300424B4");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
