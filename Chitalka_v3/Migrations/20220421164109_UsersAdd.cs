using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chitalka_v3.Migrations
{
    public partial class UsersAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usrName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pswrd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ifAdmin = table.Column<bool>(type: "bit", nullable: false),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
