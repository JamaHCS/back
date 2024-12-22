using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class LogMappingContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_LogSubjects_LogSubjectId",
                schema: "pim",
                table: "Logs");

            migrationBuilder.AlterColumn<int>(
                name: "LogSubjectId",
                schema: "pim",
                table: "Logs",
                type: "int",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "ClientIp",
                schema: "pim",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MethodName",
                schema: "pim",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestId",
                schema: "pim",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                schema: "pim",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAgent",
                schema: "pim",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                schema: "pim",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_LogSubjects_LogSubjectId",
                schema: "pim",
                table: "Logs",
                column: "LogSubjectId",
                principalSchema: "pim",
                principalTable: "LogSubjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_LogSubjects_LogSubjectId",
                schema: "pim",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ClientIp",
                schema: "pim",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "MethodName",
                schema: "pim",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "RequestId",
                schema: "pim",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                schema: "pim",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "UserAgent",
                schema: "pim",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "UserRole",
                schema: "pim",
                table: "Logs");

            migrationBuilder.AlterColumn<int>(
                name: "LogSubjectId",
                schema: "pim",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_LogSubjects_LogSubjectId",
                schema: "pim",
                table: "Logs",
                column: "LogSubjectId",
                principalSchema: "pim",
                principalTable: "LogSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
