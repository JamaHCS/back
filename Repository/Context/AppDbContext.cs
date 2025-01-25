using Domain.Entities.Auth;
using Domain.Entities.Log;
using Domain.Entities.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Repository.Utils;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("pim");

            var jamaUser = new AppUser
            {
                Email = "jama@pim.com",
                UserName = "jama@pim.com"
            };

            string hash = Utils.Utils.GetHashPassword(jamaUser, "acceso.pim");

            jamaUser = new AppUser
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                UserName = jamaUser.UserName,
                NormalizedUserName = "JAMA@PIM.COM",
                PhoneNumber = "4424051649",
                Email = jamaUser.Email,
                NormalizedEmail = "JAMA@PIM.COM",
                EmailConfirmed = true,
                PasswordHash = hash,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Jama",
                MiddleName = "Sr",
                LastName = "Developer",
                MotherLastName = "",
                CreatedAt = DateTime.UtcNow,
                DateOfBirth = new DateTime(2000, 3, 20, 0, 0, 0, DateTimeKind.Utc)
            };

            var permissions = new List<Permission>
            {
                new Permission { Id = Guid.Parse("00000000-0000-0000-0004-000000000000"), Name = "getPermissions", Description = "Permite leer la información de los permisos." },
                new Permission { Id = Guid.Parse("00000000-0000-0000-0005-000000000000"), Name = "getUser", Description = "Permite leer la información detallada del usuario." },
                new Permission { Id = Guid.Parse("00000000-0000-0000-0001-000000000000"), Name = "postUser", Description = "Permite crear usuarios." },
                new Permission { Id = Guid.Parse("00000000-0000-0000-0006-000000000000"), Name = "getRoles", Description = "Permite leer la información de los roles." },
                new Permission { Id = Guid.Parse("00000000-0000-0000-0007-000000000000"), Name = "putRoles", Description = "Permite modificar los roles." }
            };

            var superUserRole = new AppRole
            {
                Id = Guid.Parse("00000000-0000-0000-1000-000000000000"),
                Name = "SuperUser",
                NormalizedName = "SUPERUSER",
                Description = "Rol con acceso total a todas las funcionalidades",
                CreatedAt = DateTime.UtcNow
            };

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
                entity.ToTable("Users");
                entity.HasKey(b => b.Id);

                entity.Property(b => b.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(b => b.LastName).HasMaxLength(100).IsRequired();
                entity.Property(b => b.MiddleName).HasMaxLength(100).IsRequired(false);
                entity.Property(b => b.MotherLastName).HasMaxLength(100).IsRequired();
                entity.Property(b => b.DateOfBirth).IsRequired();

                entity.HasMany(u => u.Logs).WithOne(l => l.User).HasForeignKey(l => l.UserId);

                entity.HasData(jamaUser);
            });

            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasData(superUserRole);
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.HasData(new IdentityUserRole<Guid>
                {
                    UserId = jamaUser.Id,
                    RoleId = superUserRole.Id
                });
            });

            modelBuilder.Entity<IdentityRoleClaim<Guid>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            modelBuilder.Entity<IdentityUserClaim<Guid>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permissions");
                entity.HasKey(s => s.Id);

                entity.Property(b => b.Name).HasMaxLength(100).IsRequired();
                entity.Property(b => b.Description).HasMaxLength(100).IsRequired();

                entity.HasIndex(p => p.Name).IsUnique();

                entity.HasData(permissions);
            });

            var rolePermissionsSuperUser = permissions.Select(permissions => new RolePermission
            {
                RoleId = superUserRole.Id,
                PermissionId = permissions.Id
            }).ToList();

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.ToTable("RolePermissions");

                entity.HasKey(rp => new { rp.RoleId, rp.PermissionId });
                entity.HasOne(rp => rp.Role).WithMany().HasForeignKey(rp => rp.RoleId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(rp => rp.Permission).WithMany().HasForeignKey(rp => rp.PermissionId).OnDelete(DeleteBehavior.Cascade);

                entity.HasData(rolePermissionsSuperUser);
            });
        }
    }
}
