using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationForm.Migrations
{
    public partial class InitialdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Email", "Password", "RegisterDate", "UserName" },
                values: new object[] { 1, "reza2908bahrami@gmail.com", "Rezmi2908", new DateTime(2024, 4, 9, 16, 3, 58, 230, DateTimeKind.Local).AddTicks(8837), "therezmi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
