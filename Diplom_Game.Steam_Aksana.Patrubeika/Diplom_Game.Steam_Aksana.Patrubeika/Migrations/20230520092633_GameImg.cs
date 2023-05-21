using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom_Game.Steam_Aksana.Patrubeika.Migrations
{
    public partial class GameImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1,
                column: "Img",
                value: "/img/INSIDE.jpg ");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2,
                column: "Img",
                value: "/img/LIMBO.jpg ");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 3,
                column: "Img",
                value: "/img/DETROIT.jpg ");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 4,
                column: "Img",
                value: "/img/STRAY.png ");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 5,
                column: "Img",
                value: "/img/Gris.jpg ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Games");
        }
    }
}
