using System;
using System.Collections.Generic;

namespace TelstarLogistics.Models
{
    public partial class Route
    {
        public int RouteId { get; set; }
        public int City1Id { get; set; }
        public int City2Id { get; set; }
        public string TransportType { get; set; } = null!;
        public decimal Weight { get; set; }
        public int Distance { get; set; }
    }
}
