using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom_Game.Steam_Aksana.Patrubeika.Migrations
{
    public partial class AddLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserLevels",
                columns: new[] { "UserLevelId", "LevelName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Advanced" },
                    { 3, "Middle" },
                    { 4, "Junior" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserLevels",
                keyColumn: "UserLevelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserLevels",
                keyColumn: "UserLevelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserLevels",
                keyColumn: "UserLevelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserLevels",
                keyColumn: "UserLevelId",
                keyValue: 4);
        }
    }
}
