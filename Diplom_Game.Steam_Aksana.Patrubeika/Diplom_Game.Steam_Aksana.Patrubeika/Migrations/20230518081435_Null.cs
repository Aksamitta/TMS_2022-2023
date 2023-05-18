using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom_Game.Steam_Aksana.Patrubeika.Migrations
{
    public partial class Null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserLevels_UserLevelId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "CreditCartNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<int>(
                name: "UserLevelId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserLevels_UserLevelId",
                table: "AspNetUsers",
                column: "UserLevelId",
                principalTable: "UserLevels",
                principalColumn: "UserLevelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserLevels_UserLevelId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CreditCartNumber",
                table: "Orders",
                type: "int",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
