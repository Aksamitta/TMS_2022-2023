using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab24_Aksana.Patrubeika_EFComponents.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePassenger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birth",
                table: "Passengers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birth",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Passengers");
        }
    }
}
