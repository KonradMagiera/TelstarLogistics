using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelstarLogistics.Migrations
{
    public partial class AddBookingRevenueToBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BookingRevenue",
                table: "Booking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingRevenue",
                table: "Booking");
        }
    }
}
