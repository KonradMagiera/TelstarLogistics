using System;
using System.Collections.Generic;

namespace TelstarLogistics.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public string? CustEmail { get; set; }
        public int? CustPhone { get; set; }
        public string CustName { get; set; } = null!;
        public string ParcelType { get; set; } = null!;
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public DateTime Handover { get; set; }
        public bool Recommended { get; set; }
        public string CargoCenterLocations { get; set; } = null!;
        public int UserId { get; set; }
    }
}
