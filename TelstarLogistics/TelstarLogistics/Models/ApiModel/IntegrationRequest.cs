namespace TelstarLogistics.Models.ApiModel
{
    public class IntegrationRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Type { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Currency { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public bool Recommended { get; set; }

    }
}
