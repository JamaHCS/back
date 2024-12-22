using Domain.Entities;
using Domain.Entities.Log;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<AppUser> Users { get; set; } = null!;
        public DbSet<LogEvent> LogEvents { get; set; } = null!;

        public AppDbContext()
        {}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=contafacil.tech\\MSSQLSERVER2012;Database=pim;Uid=pim;Pwd=r45l7fB_1;Trust Server Certificate=true");
            }
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
                entity.Property(e => e.UserId).HasColumnName("UserId").IsRequired(false).HasColumnType("uniqueidentifier");

                entity.HasOne(e => e.User).WithMany(u => u.Logs).HasForeignKey(e => e.UserId).IsRequired(false);
                entity.HasOne(e => e.LogSubject).WithMany(s => s.LogEvents).HasForeignKey(e => e.LogSubjectId);
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
            });
        }
    }
}
