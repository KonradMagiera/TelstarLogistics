namespace TelstarLogistics.Models.ApiModel
{
    public class GetRoutesResponse
    {
        public string RouteType { get; set; }
        public DateTime DeliveryTime { get; set; }
        public float Price { get; set; }
        public List<string> Path { get; set; }
    }
}
