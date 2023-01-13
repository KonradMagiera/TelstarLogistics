using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            double priceMultiplier = 1.00;
            double recommendPriceAddition = 0;
            if (request.recommended == true) {
                recommendPriceAddition = 10;
            } else if (request.type == "liveAnimals")
            {
                priceMultiplier = 1.50;
            } else if (request.type == "cautionsParcels")
            {
                priceMultiplier = 1.75;
            } else if (request.type == "refrigertedGoods")
            {
                priceMultiplier = 1.10;
            }
            Dijkstra dijkstra = new Dijkstra();

            var travelDistance = dijkstra.GetRoute(request.from, request.to, false, true, out var path);
            List<GetRoutesResponse> routes = new List<GetRoutesResponse>();
            
            routes.Add(new GetRoutesResponse { RouteType = "fastest", DeliveryTime = new DateTime().AddHours(travelDistance * 4), Price = travelDistance * 3, Path = path });


            var travelDistance2 = dijkstra.GetRoute(request.from, request.to, true, false, out var path2);

            routes.Add(new GetRoutesResponse { RouteType = "best", DeliveryTime = new DateTime().AddHours(travelDistance2 * 4), Price = travelDistance2 * 3, Path = path2 });

            // for each route list calculate
            // fetch time and price from competitors based on route id
            // telstarPrice, oceanicPrice, indiaPrice
            // telstarDuration, oceanicDuration, indiaPrice
            // filter best, fastest and cheapest routes
            // check if request has recommended = true and if one of the route lists is only composed of car routes


            // response: Provides list of routes, one for each of types (best, Cheapest, Shortest) 

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
