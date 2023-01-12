using MessagePack;

namespace TelstarLogistics.Models.ApiModel
{
    public class TelstarRoute
    {
        public int RouteId { get; set; }
        public City StartCity { get; set; }
        public City EndCity { get; set; }
        public string TransportType { get; set; }
        public double Weight { get; set; }
        public double Cost { get; set; }
    }
}
