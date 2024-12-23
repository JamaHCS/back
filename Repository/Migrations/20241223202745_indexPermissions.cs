using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class indexPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("624399ff-f1d1-4474-8ee1-32c8763f0ebb"));

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("8eac95b4-3eac-42fe-8191-73a49237f58c"));

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("b6bf075f-4dc9-467f-a0e7-eba18f4aeb9c"));

            migrationBuilder.InsertData(
                schema: "pim",
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("b81d305c-71ba-4f98-a03f-d8cabf4d12c0"), "Permite leer usuarios", "readUser" },
                    { new Guid("be500f26-19f5-42f5-be61-7db2060363c8"), "Permite desactivar usuarios", "disableUsers" },
                    { new Guid("c5d66e00-5996-4ec8-88c0-c916fa8ac460"), "Permite crear usuarios", "createUser" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Name",
                schema: "pim",
                table: "Permissions",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissions_Name",
                schema: "pim",
                table: "Permissions");

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("b81d305c-71ba-4f98-a03f-d8cabf4d12c0"));

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("be500f26-19f5-42f5-be61-7db2060363c8"));

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("c5d66e00-5996-4ec8-88c0-c916fa8ac460"));

            migrationBuilder.InsertData(
                schema: "pim",
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("624399ff-f1d1-4474-8ee1-32c8763f0ebb"), "Permite crear usuarios", "createUser" },
                    { new Guid("8eac95b4-3eac-42fe-8191-73a49237f58c"), "Permite leer usuarios", "readUser" },
                    { new Guid("b6bf075f-4dc9-467f-a0e7-eba18f4aeb9c"), "Permite desactivar usuarios", "disableUsers" }
                });
        }
    }
}
