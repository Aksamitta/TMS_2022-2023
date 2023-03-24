using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab24_Aksana.Patrubeika_EFComponents.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TripID",
                table: "Trips",
                newName: "TripId");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Trips",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Companies",
                newName: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CompanyId",
                table: "Trips",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Companies_CompanyId",
                table: "Trips",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Companies_CompanyId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_CompanyId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "TripId",
                table: "Trips",
                newName: "TripID");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Trips",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Companies",
                newName: "CompanyID");
        }
    }
}
