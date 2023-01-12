namespace TelstarLogistics.Models.ApiModel
{
    public class ConfirmBookingRequest
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RouteId { get; set; }
    }
}
