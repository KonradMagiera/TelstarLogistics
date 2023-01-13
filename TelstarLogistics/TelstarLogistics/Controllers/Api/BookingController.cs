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
        TelstarLogisticsContext dbContext = new TelstarLogisticsContext();

        [HttpGet]
        [Route("GetEmployeeOfMonth")]
        public async Task<ActionResult> GetEmployeeOfMonth()
        {
            DateTime date = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);

            var Bookings = dbContext.Bookings
                .Where(x => x.Handover >= firstDayOfMonth);
            if(Bookings == null || Bookings.Count() == 0)
            {
                return Ok("No one");
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

            return Ok($"{topUser.FirstName} {topUser.LastName}");
        }
    }
}
