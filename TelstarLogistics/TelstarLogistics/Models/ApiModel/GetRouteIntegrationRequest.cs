using Microsoft.AspNetCore.Mvc;

namespace TelstarLogistics.Models.ApiModel
{
    public class GetRouteIntegrationRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Type { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Currency { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Depth { get; set; }
        public bool Recommended { get; set; }
    }
}
