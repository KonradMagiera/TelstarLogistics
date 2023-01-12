using System;
using System.Collections.Generic;

namespace TelstarLogistics.Models
{
    public partial class Route
    {
        public int RouteId { get; set; }
        public int StartCityId { get; set; }
        public int EndCityId { get; set; }
        public string TransportType { get; set; } = null!;
        public decimal Weight { get; set; }
        public decimal Cost { get; set; }
    }
}
