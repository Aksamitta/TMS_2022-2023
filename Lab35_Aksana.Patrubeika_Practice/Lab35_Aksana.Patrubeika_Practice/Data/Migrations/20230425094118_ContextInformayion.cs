using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab35_Aksana.Patrubeika_Practice.Data.Migrations
{
    public partial class ContextInformayion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "ClientName", "ClientSname" },
                values: new object[,]
                {
                    { 1, "Nick", "First" },
                    { 2, "Chack", "Second" },
                    { 3, "Andry", "Third" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "RoleSalary" },
                values: new object[] { 1, "Seller", 2000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeName", "RoleId" },
                values: new object[] { 1, "Mike Lang", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeName", "RoleId" },
                values: new object[] { 2, "Jhon Jhon", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeName", "RoleId" },
                values: new object[] { 3, "Nick Nick", 1 });

            migrationBuilder.InsertData(
                table: "Magazines",
                columns: new[] { "MagazineId", "AutoId", "ClientId", "Date", "EmployeeId" },
                values: new object[] { 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Magazines",
                columns: new[] { "MagazineId", "AutoId", "ClientId", "Date", "EmployeeId" },
                values: new object[] { 2, 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Magazines",
                columns: new[] { "MagazineId", "AutoId", "ClientId", "Date", "EmployeeId" },
                values: new object[] { 3, 5, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Magazines",
                keyColumn: "MagazineId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Magazines",
                keyColumn: "MagazineId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Magazines",
                keyColumn: "MagazineId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);
        }
    }
}
