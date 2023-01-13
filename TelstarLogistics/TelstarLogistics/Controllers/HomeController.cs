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

        User _loggedUser = new User();

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
            _loggedUser = searchedUser;
            return View(_user);
        }


        [HttpGet]
        public IActionResult MainPage()
        {
            BookingController bookingController = new BookingController();
            List<City> cityList = dbContext.Cities.ToList();
            if (TempData["UserRole"] != null)
            {
                ViewBag.UserRole = TempData["UserRole"].ToString();
            }
            if (TempData["UserName"] != null)
            {
                ViewBag.UserName = TempData["UserName"].ToString();
            }
            ViewBag.Cities = cityList;
            ViewBag.EOTM = getEmpotm();
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


            float priceMultiplier = 1.00f;
            float recommendPriceAddition = 0;
            if (recommended == true)
            {
                recommendPriceAddition = 10f;
            }
            else if (parcelType == "liveAnimals")
            {
                priceMultiplier = 1.50f;
            }
            else if (parcelType == "cautionsParcels")
            {
                priceMultiplier = 1.75f;
            }
            else if (parcelType == "refrigertedGoods")
            {
                priceMultiplier = 1.10f;
            }
            Dijkstra dijkstra = new Dijkstra();

            var fastestRoute = dijkstra.GetShortestRoute(source, destination, out var path);
            List<GetRoutesResponse> routes = new List<GetRoutesResponse>();

            var now = DateTime.Now;

            routes.Add(new GetRoutesResponse
            {
                RouteType = "fastest",
                DeliveryTime = now.AddHours(fastestRoute * 4),
                TelstarPrice = (fastestRoute * 3 * priceMultiplier) + recommendPriceAddition,
                Path = path,
                TotalPrice = (fastestRoute * 3 * priceMultiplier)
            });

            var now2 = DateTime.Now;
            var bestRoute = dijkstra.GetBestRoute(source, destination, out var path2);

            routes.Add(new GetRoutesResponse
            {
                RouteType = "best",
                DeliveryTime = now2.AddHours(bestRoute * 4),
                TelstarPrice = (bestRoute * 3 * priceMultiplier) + recommendPriceAddition,
                Path = path2,
                TotalPrice = (bestRoute * 3 * priceMultiplier)
            });
            var now3 = DateTime.Now;
            var cheapestRoute = dijkstra.GetNoPlaneRoute(source, destination, out var path3);

            routes.Add(new GetRoutesResponse
            {
                RouteType = "cheapest",
                DeliveryTime = now3.AddHours(bestRoute * 4),
                TelstarPrice = (cheapestRoute * 3 * priceMultiplier) + recommendPriceAddition,
                Path = path3,
                TotalPrice = (cheapestRoute * 3 * priceMultiplier)
            });


            BookingController bookingController = new BookingController();
            List<City> cityList = dbContext.Cities.ToList();
          
            ViewBag.UserName = "admin";
            ViewBag.UserRole = "admin";
            ViewBag.Cities = cityList;
            ViewBag.EOTM = getEmpotm();
            ViewBag.Results = routes;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private String getEmpotm()
        {
            DateTime date = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);

            var Bookings = dbContext.Bookings
                .Where(x => x.Handover >= firstDayOfMonth);
            if (Bookings == null || Bookings.Count() == 0)
            {
                return "No one";
            }
            IDictionary<int, decimal> userBookingRevenues = new Dictionary<int, decimal>();

            foreach (var booking in Bookings)
            {
                if (userBookingRevenues.ContainsKey(booking.UserId))
                {
                    userBookingRevenues[booking.UserId] += booking.BookingRevenue;
                }
                else
                {
                    userBookingRevenues.Add(booking.UserId, booking.BookingRevenue);
                }
            }

            int keyOfMaxValue = userBookingRevenues.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            var topUser = dbContext.Users.Find(keyOfMaxValue);
            return $"{topUser.FirstName} {topUser.LastName}";
        }
    }
}