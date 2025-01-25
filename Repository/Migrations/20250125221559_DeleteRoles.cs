using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "pim",
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0009-000000000000"), "Permite eliminar los roles.", "deleteRoles" });

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 22, 15, 57, 982, DateTimeKind.Utc).AddTicks(3380));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b427950-af78-4904-ace2-dec65d891aad", new DateTime(2025, 1, 25, 22, 15, 57, 981, DateTimeKind.Utc).AddTicks(9083), "AQAAAAIAAYagAAAAEMJhvEG+T3ngEdydu6yKNELrzJw0q4QhkPZTUAtRTN9CF/tpcCiIeK/QVEU4ZZ99qg==", "3d4a66b5-3f04-4ef1-8861-dde0f044ce27" });

            migrationBuilder.InsertData(
                schema: "pim",
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "AppRoleId" },
                values: new object[] { new Guid("00000000-0000-0000-0009-000000000000"), new Guid("00000000-0000-0000-1000-000000000000"), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0009-000000000000"), new Guid("00000000-0000-0000-1000-000000000000") });

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000000"));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 21, 1, 35, 928, DateTimeKind.Utc).AddTicks(7354));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86f2b828-f799-4aef-8e94-8f7150ab837c", new DateTime(2025, 1, 25, 21, 1, 35, 928, DateTimeKind.Utc).AddTicks(3275), "AQAAAAIAAYagAAAAEDyaCJisUHvlRY8J9eWt5IUpa5JLRqAnFE6ccXvrzMymAqK1+mHhsXW2czA0JdOFWA==", "eaa12a0c-fcb7-4143-8e94-3c5ee8e7b533" });
        }
    }
}
