using TelstarLogistics.Models;
using TelstarLogistics.Models.ApiModel;
using Microsoft.AspNetCore.Mvc;

namespace TelstarLogistics.Controllers.Api
{
    [Route("booking-api")]
    [ApiController]
    public class BookingController : Controller
    {
        [HttpGet]
        [Route("GetEmployeeOfMonth")]
        public async Task<ActionResult> GetEmployeeOfMonth()
        {
            //var DbContext = new TelstarLogisticsContext();
            return Ok(new string[] { "value1", "value2" });
        }
    }
}
