using Microsoft.AspNetCore.Mvc;

namespace TelstarLogistics.Models.ApiModel
{
    public class GetRoutesRequest
    {
        public string from { get; set; }
        public string to { get; set; }
        public string type { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
        public float width { get; set; }
        public float depth { get; set; }
        public bool recommended { get; set; }
    }
}
