using Microsoft.EntityFrameworkCore.Migrations;

namespace DbPlugin1.Migrations
{
    public partial class _100initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.CreateTable(
                name: "user",
                schema: "user",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    login = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    city = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                });

            migrationBuilder.InsertData(
                schema: "user",
                table: "user",
                columns: new[] { "user_id", "city", "email", "first_name", "last_name", "login" },
                values: new object?[] { 1L, null, "super@test.com", "Super", "Superowski", "super" });

            migrationBuilder.InsertData(
                schema: "user",
                table: "user",
                columns: new[] { "user_id", "city", "email", "first_name", "last_name", "login" },
                values: new object?[] { 2L, null, "admin@test.com", "Admin", "Adminowski", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_user_login",
                schema: "user",
                table: "user",
                column: "login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user",
                schema: "user");
        }
    }
}
