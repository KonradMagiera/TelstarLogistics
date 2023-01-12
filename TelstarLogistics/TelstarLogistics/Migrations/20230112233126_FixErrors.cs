using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelstarLogistics.Migrations
{
    public partial class FixErrors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Route");

            migrationBuilder.RenameColumn(
                name: "StartCityId",
                table: "Route",
                newName: "Distance");

            migrationBuilder.AddColumn<int>(
                name: "City1Id",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City1Id",
                table: "Route");

            migrationBuilder.RenameColumn(
                name: "Distance",
                table: "Route",
                newName: "StartCityId");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Route",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
