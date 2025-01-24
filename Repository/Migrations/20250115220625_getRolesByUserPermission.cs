using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class getRolesByUserPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "pim",
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0006-000000000000"), "Permite leer los roles y permisos por usuario.", "getRolesByUser" });

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 15, 22, 6, 24, 330, DateTimeKind.Utc).AddTicks(7514));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "08707e00-50cd-434e-a7ee-a741c3b3ff36", new DateTime(2025, 1, 15, 22, 6, 24, 330, DateTimeKind.Utc).AddTicks(3695), "AQAAAAIAAYagAAAAEH9ixB1hVzxP1KX4HuaB8nNzY55Epq3CK/tIQfGKGi9eY/CEDd2w2dxt4HxzXU/9Ig==", "4424051649", "85e2fef7-df01-45b5-83fb-f233838c7cb9" });

            migrationBuilder.InsertData(
                schema: "pim",
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "AppRoleId" },
                values: new object[] { new Guid("00000000-0000-0000-0006-000000000000"), new Guid("00000000-0000-0000-1000-000000000000"), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0006-000000000000"), new Guid("00000000-0000-0000-1000-000000000000") });

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000000"));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 13, 23, 20, 19, 472, DateTimeKind.Utc).AddTicks(8865));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "681e29fd-a071-4557-8e85-85468e5645e1", new DateTime(2025, 1, 13, 23, 20, 19, 472, DateTimeKind.Utc).AddTicks(5213), "AQAAAAIAAYagAAAAEF5lJyYrfe77qLeeN4v4JCSL6W6iKuFXqJpNEy3QEfKIDnsS8KR6bAUZPG82PYu1cA==", null, "50e4fabc-d221-494a-970e-6b3eb67855ec" });
        }
    }
}
