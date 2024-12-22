using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class LogMappingUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                schema: "pim",
                table: "Logs");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "pim",
                table: "Logs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                schema: "pim",
                table: "Logs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Users_UserId",
                schema: "pim",
                table: "Logs",
                column: "UserId",
                principalSchema: "pim",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Users_UserId",
                schema: "pim",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_UserId",
                schema: "pim",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "pim",
                table: "Logs");

            migrationBuilder.AddColumn<string>(
                name: "User",
                schema: "pim",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
