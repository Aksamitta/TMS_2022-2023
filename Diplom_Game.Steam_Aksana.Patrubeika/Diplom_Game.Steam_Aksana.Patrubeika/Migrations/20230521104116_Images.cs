using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom_Game.Steam_Aksana.Patrubeika.Migrations
{
    public partial class Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 5,
                column: "Img",
                value: "/img/Gris.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 5,
                column: "Img",
                value: "/img/Gris.jpeg");
        }
    }
}
