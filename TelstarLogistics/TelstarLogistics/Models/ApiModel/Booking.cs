namespace TelstarLogistics.Models.ApiModel
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string CustEmail { get; set; }
        public string CustName { get; set; }
        public int CustPhone { get; set; }
        public string ParcelType { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public DateTime Handover { get; set; }
        public bool Recommended { get; set; }
        //public List<double> CargoCenterLocations { get; set; }
        public int UserId { get; set; }
    }
}
