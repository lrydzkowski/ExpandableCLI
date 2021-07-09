using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbPlugin2.Migrations
{
    public partial class _100initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "operation",
                columns: table => new
                {
                    rec_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    operation_key = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    start_date_time_utc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    end_date_time_utc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operation", x => x.rec_id);
                });

            migrationBuilder.InsertData(
                table: "operation",
                columns: new[] { "rec_id", "end_date_time_utc", "operation_key", "start_date_time_utc" },
                values: new object[] { 1L, new DateTime(2021, 5, 29, 10, 10, 0, 0, DateTimeKind.Utc), "login", new DateTime(2021, 5, 29, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "operation",
                columns: new[] { "rec_id", "end_date_time_utc", "operation_key", "start_date_time_utc" },
                values: new object[] { 2L, new DateTime(2021, 6, 1, 10, 10, 0, 0, DateTimeKind.Utc), "create_user", new DateTime(2021, 6, 1, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "operation",
                columns: new[] { "rec_id", "end_date_time_utc", "operation_key", "start_date_time_utc" },
                values: new object[] { 3L, new DateTime(2021, 5, 29, 10, 10, 0, 0, DateTimeKind.Utc), "delete_user", new DateTime(2021, 5, 29, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "operation",
                columns: new[] { "rec_id", "end_date_time_utc", "operation_key", "start_date_time_utc" },
                values: new object[] { 4L, new DateTime(2021, 5, 29, 10, 10, 0, 0, DateTimeKind.Utc), "create_user", new DateTime(2021, 5, 29, 10, 0, 0, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operation");
        }
    }
}
