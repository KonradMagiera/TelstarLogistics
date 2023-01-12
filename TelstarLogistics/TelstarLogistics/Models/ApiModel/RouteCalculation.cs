namespace TelstarLogistics.Models.ApiModel
{
    public class RouteCalculation
    {
        public double CompanyPrice { get; set; }
        public double TotalPrice { get; set; }
        public double Duration { get; set; }
        public List<string> Steps { get; set; }
    }
}
