using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelstarLogistics.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    CustEmail = table.Column<string>(type: "text", nullable: true),
                    CustPhone = table.Column<int>(type: "int", nullable: true),
                    CustName = table.Column<string>(type: "text", nullable: false),
                    ParcelType = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Handover = table.Column<DateTime>(type: "datetime", nullable: false),
                    Recommended = table.Column<bool>(type: "bit", nullable: false),
                    CargoCenterLocations = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    StartCityId = table.Column<int>(type: "int", nullable: false),
                    EndCityId = table.Column<int>(type: "int", nullable: false),
                    TransportType = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
