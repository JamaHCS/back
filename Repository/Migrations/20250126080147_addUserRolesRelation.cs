using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addUserRolesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000000"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 26, 8, 1, 45, 838, DateTimeKind.Utc).AddTicks(7474));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "818efc34-cc79-447c-8fcf-f24059256079", new DateTime(2025, 1, 26, 8, 1, 45, 838, DateTimeKind.Utc).AddTicks(3837), "AQAAAAIAAYagAAAAEKC2+rO/jFpD6AT+d5lCxWMi0SkGGW/kNG+vluQbgmHR6SxX1R2t0ALzM9uVo3pCXw==", "cf9a1212-d115-4956-b31e-605ee1a1dced" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
