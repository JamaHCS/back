using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UserJamaModifications : Migration
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
                value: new DateTime(2025, 1, 13, 23, 20, 19, 472, DateTimeKind.Utc).AddTicks(8865));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "MiddleName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "681e29fd-a071-4557-8e85-85468e5645e1", new DateTime(2025, 1, 13, 23, 20, 19, 472, DateTimeKind.Utc).AddTicks(5213), new DateTime(2000, 3, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Sr", "AQAAAAIAAYagAAAAEF5lJyYrfe77qLeeN4v4JCSL6W6iKuFXqJpNEy3QEfKIDnsS8KR6bAUZPG82PYu1cA==", "50e4fabc-d221-494a-970e-6b3eb67855ec" });
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
                value: new DateTime(2025, 1, 13, 23, 16, 7, 862, DateTimeKind.Utc).AddTicks(1349));

            migrationBuilder.UpdateData(
                schema: "pim",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "MiddleName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2daea40a-67e1-403f-91ca-ce54d0e37fef", new DateTime(2025, 1, 13, 23, 16, 7, 861, DateTimeKind.Utc).AddTicks(7913), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AQAAAAIAAYagAAAAEFaLfQNgXe65SBjNJNI4rwMlJdrooLm2DJkJI9KeCM1rtLFEqJplF4Kn1QilWprPYw==", "2c4d5503-3323-46ff-b31d-a4553af47e30" });
        }
    }
}
