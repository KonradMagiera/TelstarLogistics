using TelstarLogistics.Models;
using TelstarLogistics.Models.ApiModel;
using Microsoft.AspNetCore.Mvc;
using TelstarLogistics.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var Bookings = new TelstarLogisticsContext().Bookings;
            foreach (var booking in Bookings)
            {
                //booking.pri
            }
            return Ok(new string[] { "value1", "value2" });
        }
    }
}
