using System;
using TelstarLogistics.Models.ApiModel;

namespace TelstarLogistics.Controllers.Integration
{
    public class TelstarRepository : ITelstarRepository
    {
        public TelstarRepository()
        {
            using (var context = new MyDbContext())
            {
                var cities = new List<City>
                {
                    new City
                    {
                        Name ="Joydip"
                    }
                };
                context.Cities.AddRange(cities);

                City city = new City { Name = "Joydip" };
                var routes = new List<TelstarRoute>
                {
                    new TelstarRoute {
                        StartCity = city,
                        EndCity = city,
                        TransportType ="Animal",
                        Weight = 10.0,
                        Cost = 12.0,
                    }
                };
                context.Cities.AddRange(cities);
                context.Routes.AddRange(routes);

                context.SaveChanges();
            }
        }
        public List<City> GetCities()
        {
            using (var context = new MyDbContext())
            {
                var list = context.Cities
                    .ToList();
                return list;
            }
        }

        public List<TelstarRoute> GetRoutes()
        {
            using (var context = new MyDbContext())
            {
                var list = context.Routes
                    .ToList();
                return list;
            }
        }
    }
}
