using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab24_Aksana.Patrubeika_EFComponents.Data.Migrations
{
    /// <inheritdoc />
    public partial class Reload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TripId",
                table: "Trips",
                newName: "TripID");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Companies",
                newName: "CompanyID");

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerID);
                });

            migrationBuilder.CreateTable(
                name: "PassInTrips",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    PassengerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassInTrips", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PassInTrips_Passengers_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "Passengers",
                        principalColumn: "PassengerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassInTrips_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassInTrips_PassengerID",
                table: "PassInTrips",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_PassInTrips_TripId",
                table: "PassInTrips",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassInTrips");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.RenameColumn(
                name: "TripID",
                table: "Trips",
                newName: "TripId");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Companies",
                newName: "CompanyId");
        }
    }
}
