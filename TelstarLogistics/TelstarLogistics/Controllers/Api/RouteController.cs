using Microsoft.AspNetCore.Mvc;
using TelstarLogistics.Data;
using TelstarLogistics.Models;
using TelstarLogistics.Models.ApiModel;
using TelstarLogistics.Services.RoutePlanning;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelstarLogistics.Controllers.Api
{
    [Route("internal-api")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        TelstarLogisticsContext dbContext = new TelstarLogisticsContext();

        // GET: api/<ValuesController>
        [HttpGet]
        [Route("GetCities")]
        public async Task<ActionResult> GetCities()
        {
            List<City> cities = dbContext.Cities.ToList();
            return Ok(cities);
        }

        [HttpPost]
        [Route("GetRoutes")]
        public async Task<ActionResult> GetRoutes([FromBody] GetRoutesRequest request)
        {
            float priceMultiplier = 1.00f;
            float recommendPriceAddition = 0;
            if (request.recommended == true) {
                recommendPriceAddition = 10f;
            } else if (request.type == "liveAnimals")
            {
                priceMultiplier = 1.50f;
            } else if (request.type == "cautionsParcels")
            {
                priceMultiplier = 1.75f;
            } else if (request.type == "refrigertedGoods")
            {
                priceMultiplier = 1.10f;
            }
            Dijkstra dijkstra = new Dijkstra();

            var fastestRoute = dijkstra.GetShortestRoute(request.from, request.to, out var path);
            List<GetRoutesResponse> routes = new List<GetRoutesResponse>();

            var now = DateTime.Now;
            
            routes.Add(new GetRoutesResponse { RouteType = "fastest", DeliveryTime = now.AddHours(fastestRoute * 4),
                TelstarPrice = (fastestRoute * 3 * priceMultiplier) + recommendPriceAddition, Path = path,
                TotalPrice = (fastestRoute * 3 * priceMultiplier)
            });

            var now2 = DateTime.Now;
            var bestRoute = dijkstra.GetBestRoute(request.from, request.to, out var path2);

            routes.Add(new GetRoutesResponse { RouteType = "best", DeliveryTime = now2.AddHours(bestRoute * 4), 
                TelstarPrice = (bestRoute * 3 * priceMultiplier) + recommendPriceAddition, Path = path2,
            TotalPrice = (bestRoute * 3 * priceMultiplier)
            });
            var now3 = DateTime.Now;
            var cheapestRoute = dijkstra.GetNoPlaneRoute(request.from, request.to, out var path3);

            routes.Add(new GetRoutesResponse
            { RouteType = "cheapest",DeliveryTime = now3.AddHours(bestRoute * 4),
                TelstarPrice = (cheapestRoute * 3 * priceMultiplier) + recommendPriceAddition,  Path = path3,
                TotalPrice = (cheapestRoute * 3 * priceMultiplier)
            });


            return Ok(routes);
        }

        [HttpPost]
        [Route("ConfirmBooking")]
        public async Task<ActionResult> ConfirmBooking([FromBody] ConfirmBookingRequest request)
        {
           // save booking

            //response: Booking id that the employee needs to give the customer
            return Ok(new string[] { "value1", "value2" });
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
          //          public int UserId { get; set; }
        //public string FirstName { get; set; } = null!;
        //public string LastName { get; set; } = null!;
        //public string UserName { get; set; } = null!;
        //public string Password { get; set; } = null!;
       // public string Role { get; set; } = null!;

        User user2 = new User();

            user2.UserName = "guzix";
            user2.Role = "admin";
            //response: token
            return Ok(user2);
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
