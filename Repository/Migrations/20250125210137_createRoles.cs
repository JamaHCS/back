using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class createRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000000"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Permite crear los roles.", "postRoles" });

            migrationBuilder.InsertData(
                schema: "pim",
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0008-000000000000"), "Permite modificar los roles.", "putRoles" });

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

            migrationBuilder.InsertData(
                schema: "pim",
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "AppRoleId" },
                values: new object[] { new Guid("00000000-0000-0000-0008-000000000000"), new Guid("00000000-0000-0000-1000-000000000000"), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0008-000000000000"), new Guid("00000000-0000-0000-1000-000000000000") });

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000000"));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000000"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Permite modificar los roles.", "putRoles" });

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 20, 18, 27, 873, DateTimeKind.Utc).AddTicks(7340));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "743c1bf3-8895-44e4-aaae-d26ca269a009", new DateTime(2025, 1, 25, 20, 18, 27, 873, DateTimeKind.Utc).AddTicks(3436), "AQAAAAIAAYagAAAAEACK1vzyGSBkjvws2MeTrbGdr0gc22kO1fw8CnGaFrFj5D3Vr1wQWaFFV5HbJLdshQ==", "3e38f278-c0d8-4913-8566-a4ceaccb8684" });
        }
    }
}
