using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom_Game.Steam_Aksana.Patrubeika.Migrations
{
    public partial class ChangeGameImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Games");
        }
    }
}
