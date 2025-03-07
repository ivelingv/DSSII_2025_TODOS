using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Infrastructure.Migrations
{
    public partial class Usermodelnewfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_admin",
                schema: "dbo",
                table: "users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_admin",
                schema: "dbo",
                table: "users");
        }
    }
}
