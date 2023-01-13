using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;
using System.Diagnostics;
using TelstarLogistics.Controllers.Api;
using TelstarLogistics.Data;
using TelstarLogistics.Models;
using TelstarLogistics.Models.ApiModel;
using TelstarLogistics.Services.RoutePlanning;
using static Humanizer.In;

namespace TelstarLogistics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        TelstarLogisticsContext dbContext = new TelstarLogisticsContext();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            User _user = new User();
            return View(_user);
        }

        [HttpPost]
        public IActionResult Index(User _user)
        {
            var test = _user;
            var muser = _user.UserName;
            var searchedUser = dbContext.Users.FirstOrDefault(m =>
              EF.Functions.Like(m.UserName, _user.UserName) && EF.Functions.Like(m.Password, _user.Password));
            if(searchedUser == null)
            {
                ViewBag.LoginStatus = 0;
            } else
            {
                ViewBag.LoginStatus = 1;
                ViewBag.User = searchedUser;
                TempData["UserRole"] = searchedUser.Role;
                TempData["UserName"] = searchedUser.UserName;

                return RedirectToAction("MainPage");
            }
            return View(_user);
        }


        [HttpGet]
        public IActionResult MainPage()
        {
            BookingController bookingController = new BookingController();
            List<City> cityList = dbContext.Cities.ToList();
            if (TempData["UserRole"] != null)
            {
                ViewBag.UserName = TempData["UserName"].ToString();
            }
            if (TempData["UserName"] != null)
            {
                ViewBag.UserName = TempData["UserName"].ToString();
            }
            ViewBag.Cities = cityList;
            ViewBag.EOTM = bookingController.GetEmployeeOfMonth().GetAwaiter().GetResult().ToString();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> MainPage(String source, String destination, String parcelType, int  weight, int height, int length, int width, DateTime handover, Boolean recommended)
        {        

            Boolean recomend = recommended != null && recommended;
           

            double priceMultiplier = 1.00;
            double recommendPriceAddition = 0;
            if (recommended == true)
            {
                recommendPriceAddition = 10;
            }
            else if (parcelType == "liveAnimals")
            {
                priceMultiplier = 1.50;
            }
            else if (parcelType == "cautionsParcels")
            {
                priceMultiplier = 1.75;
            }
            else if (parcelType == "refrigertedGoods")
            {
                priceMultiplier = 1.10;
            }
            Dijkstra dijkstra = new Dijkstra();

            var travelDistance = dijkstra.GetRoute(source, destination, false, true, out var path);
            List<GetRoutesResponse> routes = new List<GetRoutesResponse>();

            routes.Add(new GetRoutesResponse { RouteType = "fastest", DeliveryTime = new DateTime().AddHours(travelDistance * 4), Price = travelDistance * 3, Path = path });


            var travelDistance2 = dijkstra.GetRoute(source, destination, true, false, out var path2);

            routes.Add(new GetRoutesResponse { RouteType = "best", DeliveryTime = new DateTime().AddHours(travelDistance2 * 4), Price = travelDistance2 * 3, Path = path2 });

            // for each route list calculate
            // fetch time and price from competitors based on route id
            // telstarPrice, oceanicPrice, indiaPrice
            // telstarDuration, oceanicDuration, indiaPrice
            // filter best, fastest and cheapest routes
            // check if request has recommended = true and if one of the route lists is only composed of car routes


            // response: Provides list of routes, one for each of types (best, Cheapest, Shortest) 

            BookingController bookingController = new BookingController();
            List<City> cityList = dbContext.Cities.ToList();
            if (TempData["UserRole"] != null)
            {
                ViewBag.UserName = TempData["UserName"].ToString();
            }
            if (TempData["UserName"] != null)
            {
                ViewBag.UserName = TempData["UserName"].ToString();
            }
            ViewBag.Cities = cityList;
            ViewBag.EOTM = bookingController.GetEmployeeOfMonth().GetAwaiter().GetResult().ToString();
            ViewBag.Results = routes;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}