using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<AppUser> Users { get; set; } = null!;

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

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(b => b.Id);
                entity.Property(b => b.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(b => b.LastName).HasMaxLength(100).IsRequired();
                entity.Property(b => b.MiddleName).HasMaxLength(100).IsRequired(false);
                entity.Property(b => b.MotherLastName).HasMaxLength(100).IsRequired();
                entity.Property(b => b.DateOfBirth).IsRequired();
            });
        }
    }
}
