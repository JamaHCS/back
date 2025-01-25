using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class updateRolePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0002-000000000000"), new Guid("00000000-0000-0000-1000-000000000000") });

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0003-000000000000"), new Guid("00000000-0000-0000-1000-000000000000") });

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000000"));

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000000"));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000000"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Permite crear usuarios.", "postUser" });

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000000"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Permite leer la información de los permisos.", "getPermissions" });

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000000"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Permite leer la información detallada del usuario.", "getUser" });

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000000"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Permite leer la información de los roles.", "getRoles" });

            migrationBuilder.InsertData(
                schema: "pim",
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0007-000000000000"), "Permite modificar los roles.", "putRoles" });

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

            migrationBuilder.InsertData(
                schema: "pim",
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "AppRoleId" },
                values: new object[] { new Guid("00000000-0000-0000-0007-000000000000"), new Guid("00000000-0000-0000-1000-000000000000"), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0007-000000000000"), new Guid("00000000-0000-0000-1000-000000000000") });

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000000"));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000000"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Permite crear usuarios", "createUser" });

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000000"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Permite leer los permisos existentes", "readPermissions" });

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000000"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Permite leer la información detallada del usuario", "readUserById" });

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000000"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Permite leer los roles y permisos por usuario.", "getRolesByUser" });

            migrationBuilder.InsertData(
                schema: "pim",
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0002-000000000000"), "Permite leer usuarios", "readUser" },
                    { new Guid("00000000-0000-0000-0003-000000000000"), "Permite desactivar usuarios", "disableUsers" }
                });

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
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08707e00-50cd-434e-a7ee-a741c3b3ff36", new DateTime(2025, 1, 15, 22, 6, 24, 330, DateTimeKind.Utc).AddTicks(3695), "AQAAAAIAAYagAAAAEH9ixB1hVzxP1KX4HuaB8nNzY55Epq3CK/tIQfGKGi9eY/CEDd2w2dxt4HxzXU/9Ig==", "85e2fef7-df01-45b5-83fb-f233838c7cb9" });

            migrationBuilder.InsertData(
                schema: "pim",
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "AppRoleId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0002-000000000000"), new Guid("00000000-0000-0000-1000-000000000000"), null },
                    { new Guid("00000000-0000-0000-0003-000000000000"), new Guid("00000000-0000-0000-1000-000000000000"), null }
                });
        }
    }
}
