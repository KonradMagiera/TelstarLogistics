namespace TelstarLogistics.Models
{
    public class IntegrationResponse
    {
        public IntegrationResponse(double cost, float duration, string correlationID)
        {
            Cost = cost;
            Duration = duration;
            CorrelationID = correlationID;
        }

        public double Cost { get; set; }
        public float Duration { get; set; }
        public string CorrelationID { get; set; }
    }
}
