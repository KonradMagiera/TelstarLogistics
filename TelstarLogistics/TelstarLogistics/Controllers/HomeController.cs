using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;
using System.Diagnostics;
using TelstarLogistics.Controllers.Api;
using TelstarLogistics.Data;
using TelstarLogistics.Models;

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


        public IActionResult MainPage()
        {
            BookingController bookingController = new BookingController();
            List<City> cityList = dbContext.Cities.ToList();
            ViewBag.UserRole = TempData["UserRole"].ToString();
            ViewBag.UserName = TempData["UserName"].ToString();
            ViewBag.Cities = cityList;
            ViewBag.EOTM = bookingController.GetEmployeeOfMonth().GetAwaiter().GetResult().ToString();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}