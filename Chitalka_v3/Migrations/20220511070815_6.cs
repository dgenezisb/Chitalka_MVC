using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chitalka_v3.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsrNotesId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UsrNotesId",
                table: "User",
                column: "UsrNotesId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UsrNotes_UsrNotesId",
                table: "User",
                column: "UsrNotesId",
                principalTable: "UsrNotes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UsrNotes_UsrNotesId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UsrNotesId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UsrNotesId",
                table: "User");
        }
    }
}
