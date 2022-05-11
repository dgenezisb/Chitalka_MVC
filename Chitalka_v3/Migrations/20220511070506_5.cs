using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chitalka_v3.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsrNotes_User_Userid",
                table: "UsrNotes");

            migrationBuilder.DropIndex(
                name: "IX_UsrNotes_Userid",
                table: "UsrNotes");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "UsrNotes");

            migrationBuilder.DropColumn(
                name: "UsrNotesId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "UsrNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "UsrNotes");

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "UsrNotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsrNotesId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsrNotes_Userid",
                table: "UsrNotes",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_UsrNotes_User_Userid",
                table: "UsrNotes",
                column: "Userid",
                principalTable: "User",
                principalColumn: "id");
        }
    }
}
