using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom_Game.Steam_Aksana.Patrubeika.Migrations
{
    public partial class AddFKUserLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserLevels_UserLevelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserLevelId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserLevels_UserLevelId",
                table: "AspNetUsers",
                column: "UserLevelId",
                principalTable: "UserLevels",
                principalColumn: "UserLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserLevels_UserLevelId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserLevelId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserLevels_UserLevelId",
                table: "AspNetUsers",
                column: "UserLevelId",
                principalTable: "UserLevels",
                principalColumn: "UserLevelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
