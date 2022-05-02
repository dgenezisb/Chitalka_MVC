using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chitalka_v3.Migrations
{
    public partial class added_inp_field_fck_this_shit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "inpAuthor",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inpCentuary",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inpCountry",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inpGenre",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inpImage",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inpAuthor",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "inpCentuary",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "inpCountry",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "inpGenre",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "inpImage",
                table: "Books");
        }
    }
}
