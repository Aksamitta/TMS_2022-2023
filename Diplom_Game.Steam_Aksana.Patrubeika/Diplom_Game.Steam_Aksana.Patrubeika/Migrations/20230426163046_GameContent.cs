using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom_Game.Steam_Aksana.Patrubeika.Migrations
{
    public partial class GameContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeveloperType",
                table: "Developers",
                newName: "DeveloperSummary");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Games",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "DeveloperId", "DeveloperName", "DeveloperSummary" },
                values: new object[,]
                {
                    { 1, "Nomada Studio", "Devolver Digital recommends only the most exquisite video games for the distinguished gamer and their refined taste. Voted 'Best Video Game Label Ever' 2016, 2017, 2021.." },
                    { 2, "Quantic Dream", "Quantic Dream is an award-winning French video game developer and publisher founded to create AAA games with a focus on emotional, interactive storytelling and innovation in narrative." },
                    { 3, "Playdead", "Playdead is an independent game developer and publisher based in Copenhagen, Denmark. We are hard at work on bringing LIMBO and INSIDE to more players - and on making new games." },
                    { 4, "Annapurna Interactive", "Established in 2016, Annapurna Interactive works with game creators from around the world, helping them create and release personal experiences for everyone." }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "DeveloperId", "GameName", "Genre", "Price", "ReleaseDate", "Reviews", "Summary" },
                values: new object[,]
                {
                    { 1, 3, "INSIDE", "Platformer", 10.49, new DateTime(2016, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overwhelmingly Positive", "Hunted and alone, a boy finds himself drawn into the center of a dark project. INSIDE is a dark, narrative-driven platformer combining intense action with challenging puzzles. It has been critically acclaimed for its moody art style, ambient soundtrack and unsettling atmosphere." },
                    { 2, 3, "LIMBO", "Platformer", 6.29, new DateTime(2011, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Very Positive", "Uncertain of his sister's fate, a boy enters LIMBO" },
                    { 3, 2, "Detroit: Become Human", "Adventure", 19.989999999999998, new DateTime(2020, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overwhelmingly Positive", "Detroit: Become Human puts the destiny of both mankind and androids in your hands, taking you to a near future where machines have become more intelligent than humans. Every choice you make affects the outcome of the game, with one of the most intricately branching narratives ever created." },
                    { 4, 4, "Stray", "Adventure", 15.99, new DateTime(2022, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overwhelmingly Positive", "Lost, alone and separated from family, a stray cat must untangle an ancient mystery to escape a long-forgotten cybercity and find their way home." },
                    { 5, 1, "Gris", "Adventure", 9.4900000000000002, new DateTime(2018, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overwhelmingly Positive", "Gris is a hopeful young girl lost in her own world, dealing with a painful experience in her life. Her journey through sorrow is manifested in her dress, which grants new abilities to better navigate her faded reality." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "DeveloperId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "DeveloperId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "DeveloperId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "DeveloperId",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "DeveloperSummary",
                table: "Developers",
                newName: "DeveloperType");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Games",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
