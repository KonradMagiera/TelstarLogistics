using Microsoft.AspNetCore.Mvc;

namespace TelstarLogistics.Models.ApiModel
{
    public class GetRoutesRequest
    {
        public string to { get; set; }
        public string type { get; set; }

    }
}
