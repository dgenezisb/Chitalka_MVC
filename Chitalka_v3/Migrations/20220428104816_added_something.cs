using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chitalka_v3.Migrations
{
    public partial class added_something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Books",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Books",
                table: "Author");
        }
    }
}
