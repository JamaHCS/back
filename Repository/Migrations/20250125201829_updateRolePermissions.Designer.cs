﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Context;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250125201829_updateRolePermissions")]
    partial class updateRolePermissions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("pim")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Auth.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastLoginAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MotherLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "pim");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "743c1bf3-8895-44e4-aaae-d26ca269a009",
                            CreatedAt = new DateTime(2025, 1, 25, 20, 18, 27, 873, DateTimeKind.Utc).AddTicks(3436),
                            DateOfBirth = new DateTime(2000, 3, 20, 0, 0, 0, 0, DateTimeKind.Utc),
                            Deleted = false,
                            Email = "jama@pim.com",
                            EmailConfirmed = true,
                            FirstName = "Jama",
                            LastName = "Developer",
                            LockoutEnabled = false,
                            MiddleName = "Sr",
                            MotherLastName = "",
                            NormalizedEmail = "JAMA@PIM.COM",
                            NormalizedUserName = "JAMA@PIM.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEACK1vzyGSBkjvws2MeTrbGdr0gc22kO1fw8CnGaFrFj5D3Vr1wQWaFFV5HbJLdshQ==",
                            PhoneNumber = "4424051649",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3e38f278-c0d8-4913-8566-a4ceaccb8684",
                            TwoFactorEnabled = false,
                            UserName = "jama@pim.com"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Log.LogEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientIp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ClientIp");

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Exception");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Level");

                    b.Property<int?>("LogSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("LogSubjectId");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Message");

                    b.Property<string>("MessageTemplate")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MessageTemplate");

                    b.Property<string>("Method")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Method");

                    b.Property<string>("MethodName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MethodName");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Path");

                    b.Property<string>("Properties")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Properties");

                    b.Property<string>("RequestId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RequestId");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ServiceName");

                    b.Property<DateTimeOffset?>("TimeStamp")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("TimeStamp");

                    b.Property<string>("UserAgent")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserAgent");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserRole");

                    b.HasKey("Id");

                    b.HasIndex("LogSubjectId")
                        .HasDatabaseName("IX_Logs_LogSubjectId");

                    b.HasIndex("TimeStamp")
                        .HasDatabaseName("IX_Logs_TimeStamp");

                    b.HasIndex("UserId")
                        .HasDatabaseName("IX_Logs_UserId");

                    b.ToTable("Logs", "pim");
                });

            modelBuilder.Entity("Domain.Entities.Log.LogSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogSubjects", "pim");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "System"
                        },
                        new
                        {
                            Id = 2,
                            Description = "User"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Roles.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", "pim");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-1000-000000000000"),
                            CreatedAt = new DateTime(2025, 1, 25, 20, 18, 27, 873, DateTimeKind.Utc).AddTicks(7340),
                            Description = "Rol con acceso total a todas las funcionalidades",
                            Name = "SuperUser",
                            NormalizedName = "SUPERUSER"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Roles.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Permissions", "pim");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0004-000000000000"),
                            Description = "Permite leer la información de los permisos.",
                            Name = "getPermissions"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0005-000000000000"),
                            Description = "Permite leer la información detallada del usuario.",
                            Name = "getUser"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0001-000000000000"),
                            Description = "Permite crear usuarios.",
                            Name = "postUser"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0006-000000000000"),
                            Description = "Permite leer la información de los roles.",
                            Name = "getRoles"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0007-000000000000"),
                            Description = "Permite modificar los roles.",
                            Name = "putRoles"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Roles.RolePermission", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("AppRoleId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions", "pim");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("00000000-0000-0000-1000-000000000000"),
                            PermissionId = new Guid("00000000-0000-0000-0004-000000000000")
                        },
                        new
                        {
                            RoleId = new Guid("00000000-0000-0000-1000-000000000000"),
                            PermissionId = new Guid("00000000-0000-0000-0005-000000000000")
                        },
                        new
                        {
                            RoleId = new Guid("00000000-0000-0000-1000-000000000000"),
                            PermissionId = new Guid("00000000-0000-0000-0001-000000000000")
                        },
                        new
                        {
                            RoleId = new Guid("00000000-0000-0000-1000-000000000000"),
                            PermissionId = new Guid("00000000-0000-0000-0006-000000000000")
                        },
                        new
                        {
                            RoleId = new Guid("00000000-0000-0000-1000-000000000000"),
                            PermissionId = new Guid("00000000-0000-0000-0007-000000000000")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "pim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "pim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "pim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "pim");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("00000000-0000-0000-0000-000000000001"),
                            RoleId = new Guid("00000000-0000-0000-1000-000000000000")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "pim");
                });

            modelBuilder.Entity("Domain.Entities.Log.LogEvent", b =>
                {
                    b.HasOne("Domain.Entities.Log.LogSubject", "LogSubject")
                        .WithMany("LogEvents")
                        .HasForeignKey("LogSubjectId");

                    b.HasOne("Domain.Entities.Auth.AppUser", "User")
                        .WithMany("Logs")
                        .HasForeignKey("UserId");

                    b.Navigation("LogSubject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Roles.RolePermission", b =>
                {
                    b.HasOne("Domain.Entities.Roles.AppRole", null)
                        .WithMany("RolePermissions")
                        .HasForeignKey("AppRoleId");

                    b.HasOne("Domain.Entities.Roles.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Roles.AppRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.Roles.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.Auth.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.Auth.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.Roles.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Auth.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.Auth.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Auth.AppUser", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("Domain.Entities.Log.LogSubject", b =>
                {
                    b.Navigation("LogEvents");
                });

            modelBuilder.Entity("Domain.Entities.Roles.AppRole", b =>
                {
                    b.Navigation("RolePermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
