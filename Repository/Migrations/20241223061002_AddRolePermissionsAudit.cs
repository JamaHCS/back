using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddRolePermissionsAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "pim",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "pim",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "pim",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "pim",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "pim",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "pim",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "pim",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "pim",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "pim",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "pim",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "pim",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "pim",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "pim",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "pim",
                table: "Permissions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "pim",
                table: "RolePermissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "pim",
                table: "RolePermissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "pim",
                table: "RolePermissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "pim",
                table: "RolePermissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "pim",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "pim",
                table: "RolePermissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                schema: "pim",
                table: "RolePermissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "pim",
                table: "Permissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "pim",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "pim",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "pim",
                table: "Permissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "pim",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "pim",
                table: "Permissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                schema: "pim",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
