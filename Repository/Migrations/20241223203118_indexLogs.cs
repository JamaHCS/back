using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class indexLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("2bd4295d-7e20-4cd8-a50e-8aca83162bdc"), "Permite desactivar usuarios", "disableUsers" },
                    { new Guid("6db40991-66fa-4532-8d8d-8428efb07ed7"), "Permite crear usuarios", "createUser" },
                    { new Guid("a8867344-2aac-4c87-92dd-4a962fee4f6a"), "Permite leer usuarios", "readUser" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_TimeStamp",
                schema: "pim",
                table: "Logs",
                column: "TimeStamp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Logs_TimeStamp",
                schema: "pim",
                table: "Logs");

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2bd4295d-7e20-4cd8-a50e-8aca83162bdc"));

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("6db40991-66fa-4532-8d8d-8428efb07ed7"));

            migrationBuilder.DeleteData(
                schema: "pim",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a8867344-2aac-4c87-92dd-4a962fee4f6a"));

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
        }
    }
}
