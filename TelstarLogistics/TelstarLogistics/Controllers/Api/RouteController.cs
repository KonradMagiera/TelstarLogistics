using Microsoft.AspNetCore.Mvc;
using TelstarLogistics.Models;
using TelstarLogistics.Models.ApiModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelstarLogistics.Controllers.Api
{
    [Route("internal-api")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("GetCities")]
        public async Task<ActionResult> GetCities()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        [HttpPost]
        [Route("GetRoutes")]
        public async Task<ActionResult> GetRoutes([FromBody] GetRoutesRequest request)
        {
            //exampleGetRoutes(from, type, weight, height, width, depth, recommended);

            //response: Provides list of routes, one for each of types (best, Cheapest, Shortest) 
            return Ok(new string[] { "value1", "value2" });
        }

        [HttpPost]
        [Route("ConfirmBooking")]
        public async Task<ActionResult> ConfirmBooking([FromBody] ConfirmBookingRequest request)
        {

            //response: Booking id that the employee needs to give the customer
            return Ok(new string[] { "value1", "value2" });
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {

            //response: token
            return Ok(new string[] { "value1", "value2" });
        }


        [HttpPost]
        [Route("Logout")]
        public async Task<ActionResult> Logout([FromBody] LogoutRequest request)
        {
            // flush token

            return Ok(new string[] { "value1", "value2" });
        }
    }
}
