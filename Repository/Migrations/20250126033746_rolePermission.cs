using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class rolePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Roles_AppRoleId1",
                schema: "pim",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_AppRoleId1",
                schema: "pim",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "AppRoleId1",
                schema: "pim",
                table: "RolePermissions");

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 26, 3, 37, 45, 79, DateTimeKind.Utc).AddTicks(5377));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "509f8eb1-46f0-476c-ba99-4c941efacd0a", new DateTime(2025, 1, 26, 3, 37, 45, 79, DateTimeKind.Utc).AddTicks(1978), "AQAAAAIAAYagAAAAELREwQ4pK0b5aWWGaAZcGc18IEmsIccUEe8L9azRngOhXSocWHFnNllwyiFFW9NRVg==", "73e6bbd7-db64-4adc-9cd9-f95f9cb643bb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppRoleId1",
                schema: "pim",
                table: "RolePermissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "AppRoleId", "PermissionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-1000-000000000000"), new Guid("00000000-0000-0000-0001-000000000000") },
                column: "AppRoleId1",
                value: null);

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "AppRoleId", "PermissionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-1000-000000000000"), new Guid("00000000-0000-0000-0004-000000000000") },
                column: "AppRoleId1",
                value: null);

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "AppRoleId", "PermissionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-1000-000000000000"), new Guid("00000000-0000-0000-0005-000000000000") },
                column: "AppRoleId1",
                value: null);

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "AppRoleId", "PermissionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-1000-000000000000"), new Guid("00000000-0000-0000-0006-000000000000") },
                column: "AppRoleId1",
                value: null);

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "AppRoleId", "PermissionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-1000-000000000000"), new Guid("00000000-0000-0000-0007-000000000000") },
                column: "AppRoleId1",
                value: null);

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "AppRoleId", "PermissionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-1000-000000000000"), new Guid("00000000-0000-0000-0008-000000000000") },
                column: "AppRoleId1",
                value: null);

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "AppRoleId", "PermissionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-1000-000000000000"), new Guid("00000000-0000-0000-0009-000000000000") },
                column: "AppRoleId1",
                value: null);

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 26, 3, 30, 41, 187, DateTimeKind.Utc).AddTicks(3276));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80151848-fcf9-4107-b8e3-ca456bd92d05", new DateTime(2025, 1, 26, 3, 30, 41, 186, DateTimeKind.Utc).AddTicks(9359), "AQAAAAIAAYagAAAAEB3DqRLS3BOGKZRcDPpl63xW1UdXMch9yWu6CB/W28iM5iuHI5ghyQLG/9qIoDfMsQ==", "d704cdfb-85a8-4dda-9e06-57778bd38d7d" });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_AppRoleId1",
                schema: "pim",
                table: "RolePermissions",
                column: "AppRoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_AppRoleId1",
                schema: "pim",
                table: "RolePermissions",
                column: "AppRoleId1",
                principalSchema: "pim",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
