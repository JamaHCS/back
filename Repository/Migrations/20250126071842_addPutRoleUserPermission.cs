using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addPutRoleUserPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "pim",
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0002-000000000000"), "Permite modificar los roles de los usuarios.", "putUserRoles" });

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 26, 7, 18, 40, 762, DateTimeKind.Utc).AddTicks(9414));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4c51547-6fe1-4320-bf60-14b1cdc4eeaa", new DateTime(2025, 1, 26, 7, 18, 40, 762, DateTimeKind.Utc).AddTicks(5969), "AQAAAAIAAYagAAAAEF1i/ZLURQxSePTYtann18z0mmsTQ5Dr/17qxKKzFuUdg+NHfWbER7AsU7uAi4rv+w==", "87d82c49-5d4d-41cc-b470-56f4d7b755d9" });

            migrationBuilder.InsertData(
                schema: "pim",
                table: "RolePermissions",
                columns: new[] { "AppRoleId", "PermissionId" },
                values: new object[] { new Guid("00000000-0000-0000-1000-000000000000"), new Guid("00000000-0000-0000-0002-000000000000") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "pim",
                table: "RolePermissions",
                keyColumns: new[] { "AppRoleId", "PermissionId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-1000-000000000000"), new Guid("00000000-0000-0000-0002-000000000000") });

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000000"));

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
    }
}
