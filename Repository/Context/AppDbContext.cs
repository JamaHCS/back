﻿using Domain.Entities.Auth;
using Domain.Entities.Log;
using Domain.Entities.Roles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Repository.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<LogEvent> LogEvents { get; set; } = null!;
        public DbSet<LogSubject> LogSubjects { get; set; } = null!;
        public DbSet<Permission> Permissions { get; set; } = default!;
        public DbSet<RolePermission> RolePermissions { get; set; } = default!;

        public AppDbContext()
        {}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=contafacil.tech\\MSSQLSERVER2012;Database=pim;Uid=pim;Pwd=r45l7fB_1;Trust Server Certificate=true");

            optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("pim");

            modelBuilder.Entity<LogSubject>(entity =>
            {
                entity.ToTable("LogSubjects");
                entity.HasKey(s => s.Id);

                entity.HasMany(s => s.LogEvents).WithOne(le => le.LogSubject).HasForeignKey(le => le.LogSubjectId);

                entity.HasData(
                    new LogSubject { Id = 1, Description = "System" },
                    new LogSubject { Id = 2, Description = "User" }
                );
            });

            modelBuilder.Entity<LogEvent>(entity =>
            {
                entity.ToTable("Logs");          
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Message).HasColumnName("Message").IsRequired(false);
                entity.Property(e => e.MessageTemplate).HasColumnName("MessageTemplate").IsRequired(false);
                entity.Property(e => e.Level).HasColumnName("Level").IsRequired(false);
                entity.Property(e => e.TimeStamp).HasColumnName("TimeStamp").IsRequired(false);
                entity.Property(e => e.Exception).HasColumnName("Exception").IsRequired(false);
                entity.Property(e => e.Properties).HasColumnName("Properties").IsRequired(false);
                entity.Property(e => e.LogSubjectId).HasColumnName("LogSubjectId").HasDefaultValue(1);
                entity.Property(e => e.RequestId).HasColumnName("RequestId").IsRequired(false);
                entity.Property(e => e.ClientIp).HasColumnName("ClientIp").IsRequired(false);
                entity.Property(e => e.UserAgent).HasColumnName("UserAgent").IsRequired(false);
                entity.Property(e => e.UserRole).HasColumnName("UserRole").IsRequired(false);
                entity.Property(e => e.ServiceName).HasColumnName("ServiceName").IsRequired(false);
                entity.Property(e => e.MethodName).HasColumnName("MethodName").IsRequired(false);
                entity.Property(e => e.UserId).HasColumnName("UserId").IsRequired(false).HasColumnType("uniqueidentifier");
                entity.Property(e => e.Path).HasColumnName("Path").IsRequired(false);
                entity.Property(e => e.Method).HasColumnName("Method").IsRequired(false);

                entity.HasOne(e => e.User).WithMany(u => u.Logs).HasForeignKey(e => e.UserId).IsRequired(false);
                entity.HasOne(e => e.LogSubject).WithMany(s => s.LogEvents).HasForeignKey(e => e.LogSubjectId);

                entity.HasIndex(e => e.LogSubjectId).HasDatabaseName("IX_Logs_LogSubjectId");
                entity.HasIndex(e => e.UserId).HasDatabaseName("IX_Logs_UserId");
                entity.HasIndex(e => e.TimeStamp).HasDatabaseName("IX_Logs_TimeStamp");
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(b => b.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(b => b.LastName).HasMaxLength(100).IsRequired();
                entity.Property(b => b.MiddleName).HasMaxLength(100).IsRequired(false);
                entity.Property(b => b.MotherLastName).HasMaxLength(100).IsRequired();
                entity.Property(b => b.DateOfBirth).IsRequired();

                entity.HasMany(u => u.Logs).WithOne(l => l.User).HasForeignKey(l => l.UserId);
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.ToTable("RolePermissions");

                entity.HasKey(rp => new { rp.RoleId, rp.PermissionId });
                entity.HasOne(rp => rp.Role).WithMany().HasForeignKey(rp => rp.RoleId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(rp => rp.Permission).WithMany().HasForeignKey(rp => rp.PermissionId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permissions");
                entity.HasKey(s => s.Id);

                entity.Property(b => b.Name).HasMaxLength(100).IsRequired();
                entity.Property(b => b.Description).HasMaxLength(100).IsRequired();

                entity.HasIndex(p => p.Name).IsUnique();

                entity.HasData(
                   new Permission { Id = Guid.NewGuid(), Name = "createUser", Description = "Permite crear usuarios" },
                   new Permission { Id = Guid.NewGuid(), Name = "readUser", Description = "Permite leer usuarios" },
                   new Permission { Id = Guid.NewGuid(), Name = "disableUsers", Description = "Permite desactivar usuarios" }
               );
            });
        }
    }
}
