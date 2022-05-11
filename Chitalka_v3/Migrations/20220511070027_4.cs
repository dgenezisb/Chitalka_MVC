using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chitalka_v3.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsrNotes_User_UserId",
                table: "UsrNotes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UsrNotes",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_UsrNotes_UserId",
                table: "UsrNotes",
                newName: "IX_UsrNotes_Userid");

            migrationBuilder.AddColumn<int>(
                name: "UsrNotesId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsrNotes_User_Userid",
                table: "UsrNotes",
                column: "Userid",
                principalTable: "User",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsrNotes_User_Userid",
                table: "UsrNotes");

            migrationBuilder.DropColumn(
                name: "UsrNotesId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "UsrNotes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsrNotes_Userid",
                table: "UsrNotes",
                newName: "IX_UsrNotes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsrNotes_User_UserId",
                table: "UsrNotes",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id");
        }
    }
}
