using TelstarLogistics.Models;
using Route = TelstarLogistics.Models.Route;

namespace TelstarLogistics.Data;

public class DbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<TelstarLogisticsContext>();

        if (context is null) return;

        ClearDb(context);

        if (!context.Cities.Any())
        {
            context.Cities.AddRange(new List<City>
            {
                new()
                {
                    CityId = 1,
                    Name = "Tanger"
                },
                new()
                {
                    CityId = 2,
                    Name = "Marrakesh"
                },
                new()
                {
                    CityId = 3,
                    Name = "Guld Kysten"
                },
                new()
                {
                    CityId = 4,
                    Name = "Hvalbugten"
                },
                new()
                {
                    CityId = 5,
                    Name = "Sierra Keibe"
                },
                new()
                {
                    CityId = 6,
                    Name = "St. Helena"
                },
                new()
                {
                    CityId = 7,
                    Name = "Kapstaden"
                },
                new()
                {
                    CityId = 8,
                    Name = "Dragebjerget"
                },
                new()
                {
                    CityId = 9,
                    Name = "Tripoli"
                },
                new()
                {
                    CityId = 10,
                    Name = "Darfur"
                },
                new()
                {
                    CityId = 11,
                    Name = "Suakin"
                },
                new()
                {
                    CityId = 12,
                    Name = "Luanda"
                },
                new()
                {
                    CityId = 13,
                    Name = "Amatave"
                },
                new()
                {
                    CityId = 14,
                    Name = "Kap Guardafui"
                },
                new()
                {
                    CityId = 15,
                    Name = "Sierra Leone"
                },
                new()
                {
                    CityId = 16,
                    Name = "Kabalo"
                },
                new()
                {
                    CityId = 17,
                    Name = "Victoria Søen"
                },
                new()
                {
                    CityId = 18,
                    Name = "Kap St. Marie"
                },
                new()
                {
                    CityId = 19,
                    Name = "Cairo"
                },
                new()
                {
                    CityId = 20,
                    Name = "De Kanariske"
                },
                new()
                {
                    CityId = 21,
                    Name = "Dakar"
                },
                new()
                {
                    CityId = 22,
                    Name = "Slave Kysten"
                },
                new()
                {
                    CityId = 23,
                    Name = "St. Marie"
                },
                new()
                {
                    CityId = 24,
                    Name = "Mocambique"
                },
                new()
                {
                    CityId = 25,
                    Name = "Sakin"
                },
                new()
                {
                    CityId = 26,
                    Name = "Tunis"
                },
                new()
                {
                    CityId = 27,
                    Name = "Omdurman"
                },
                new()
                {
                    CityId = 28,
                    Name = "Sahara"
                },
                new()
                {
                    CityId = 29,
                    Name = "Timbuktu"
                },
                new()
                {
                    CityId = 30,
                    Name = "Wadai"
                },
                new()
                {
                    CityId = 31,
                    Name = "Congo"
                },
                new()
                {
                    CityId = 32,
                    Name = "Launda"
                },
                new()
                {
                    CityId = 33,
                    Name = "Addis Abeba"
                },
                new()
                {
                    CityId = 34,
                    Name = "Zanzibar"
                },
                new()
                {
                    CityId = 35,
                    Name = "Victoria Faldene"
                },
                new()
                {
                    CityId = 36,
                    Name = "Slavekysten"
                },
                new()
                {
                    CityId = 37,
                    Name = "Bahr el Ghazal"
                },
                new()
                {
                    CityId = 38,
                    Name = "Siera Leone"
                }
            });

            context.SaveChanges();
        }

        if (!context.Routes.Any())
        {
            var rnd = new Random();
            context.Routes.AddRange(new List<Route>
            {
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 26,
                    EndCityId = 9,
                    TransportType = "car",
                    Weight = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 9,
                    EndCityId = 27,
                    TransportType = "car",
                    Weight = 6
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 27,
                    EndCityId = 19,
                    TransportType = "car",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 27,
                    EndCityId = 10,
                    TransportType = "car",
                    Weight = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 10,
                    EndCityId = 11,
                    TransportType = "car",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 11,
                    EndCityId = 33,
                    TransportType = "car",
                    Weight = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 10,
                    EndCityId = 30,
                    TransportType = "car",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 10,
                    EndCityId = 36,
                    TransportType = "car",
                    Weight = 7
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 10,
                    EndCityId = 37,
                    TransportType = "car",
                    Weight = 2
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 10,
                    EndCityId = 28,
                    TransportType = "car",
                    Weight = 8
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 28,
                    EndCityId = 2,
                    TransportType = "car",
                    Weight = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 28,
                    EndCityId = 1,
                    TransportType = "car",
                    Weight = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 1,
                    EndCityId = 26,
                    TransportType = "car",
                    Weight = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 2,
                    EndCityId = 21,
                    TransportType = "car",
                    Weight = 8
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 21,
                    EndCityId = 15,
                    TransportType = "car",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 15,
                    EndCityId = 3,
                    TransportType = "car",
                    Weight = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 15,
                    EndCityId = 29,
                    TransportType = "car",
                    Weight = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 29,
                    EndCityId = 36,
                    TransportType = "car",
                    Weight = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 30,
                    EndCityId = 36,
                    TransportType = "car",
                    Weight = 7
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 30,
                    EndCityId = 31,
                    TransportType = "car",
                    Weight = 6
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 31,
                    EndCityId = 36,
                    TransportType = "car",
                    Weight = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 31,
                    EndCityId = 32,
                    TransportType = "car",
                    Weight = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 32,
                    EndCityId = 16,
                    TransportType = "car",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 16,
                    EndCityId = 17,
                    TransportType = "car",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 17,
                    EndCityId = 37,
                    TransportType = "car",
                    Weight = 2
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 17,
                    EndCityId = 33,
                    TransportType = "car",
                    Weight = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 33,
                    EndCityId = 14,
                    TransportType = "car",
                    Weight = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 32,
                    EndCityId = 24,
                    TransportType = "car",
                    Weight = 10
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 17,
                    EndCityId = 24,
                    TransportType = "car",
                    Weight = 6
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 34,
                    EndCityId = 24,
                    TransportType = "car",
                    Weight = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 34,
                    EndCityId = 14,
                    TransportType = "car",
                    Weight = 6
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 24,
                    EndCityId = 35,
                    TransportType = "car",
                    Weight = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 35,
                    EndCityId = 4,
                    TransportType = "car",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 35,
                    EndCityId = 8,
                    TransportType = "car",
                    Weight = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 8,
                    EndCityId = 24,
                    TransportType = "car",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 4,
                    EndCityId = 7,
                    TransportType = "car",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 1,
                    EndCityId = 20,
                    TransportType = "boat",
                    Weight = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 20,
                    EndCityId = 21,
                    TransportType = "boat",
                    Weight = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 21,
                    EndCityId = 15,
                    TransportType = "boat",
                    Weight = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 21,
                    EndCityId = 6,
                    TransportType = "boat",
                    Weight = 10
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 15,
                    EndCityId = 3,
                    TransportType = "boat",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 3,
                    EndCityId = 22,
                    TransportType = "boat",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 3,
                    EndCityId = 4,
                    TransportType = "boat",
                    Weight = 11
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 22,
                    EndCityId = 4,
                    TransportType = "boat",
                    Weight = 9
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 6,
                    EndCityId = 4,
                    TransportType = "boat",
                    Weight = 10
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 6,
                    EndCityId = 7,
                    TransportType = "boat",
                    Weight = 9
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 7,
                    EndCityId = 18,
                    TransportType = "boat",
                    Weight = 8
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 18,
                    EndCityId = 24,
                    TransportType = "boat",
                    Weight = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 24,
                    EndCityId = 14,
                    TransportType = "boat",
                    Weight = 8
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 14,
                    EndCityId = 13,
                    TransportType = "boat",
                    Weight = 8
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 14,
                    EndCityId = 25,
                    TransportType = "boat",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 11,
                    EndCityId = 19,
                    TransportType = "boat",
                    Weight = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 19,
                    EndCityId = 26,
                    TransportType = "boat",
                    Weight = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 26,
                    EndCityId = 1,
                    TransportType = "boat",
                    Weight = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 1,
                    EndCityId = 2,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 1,
                    EndCityId = 9,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 2,
                    EndCityId = 15,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 2,
                    EndCityId = 3,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 3,
                    EndCityId = 12,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 3,
                    EndCityId = 4,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 3,
                    EndCityId = 9,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 4,
                    EndCityId = 7,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 5,
                    EndCityId = 6,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 6,
                    EndCityId = 7,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 7,
                    EndCityId = 16,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 7,
                    EndCityId = 8,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 8,
                    EndCityId = 17,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 7,
                    EndCityId = 18,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 7,
                    EndCityId = 13,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 9,
                    EndCityId = 10,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 10,
                    EndCityId = 16,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 10,
                    EndCityId = 11,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 11,
                    EndCityId = 19,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 11,
                    EndCityId = 17,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 12,
                    EndCityId = 4,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 13,
                    EndCityId = 14,
                    TransportType = "plane",
                    Weight = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    StartCityId = 14,
                    EndCityId = 17,
                    TransportType = "plane",
                    Weight = 1
                }
            });

            context.SaveChanges();
        }

        if (!context.Users.Any())
        {
            context.Users.AddRange(new List<User>
            {
                new()
                {
                    UserId = 0,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    UserName = "admin",
                    Password = "admin",
                    Role = "admin"
                },
                new()
                {
                    UserId = 1,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    UserName = "SubiraOkafor",
                    Password = "Ecertakestraingerstiontletenolga9",
                    Role = "caseWorker"
                },
                new()
                {
                    UserId = 2,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    UserName = "JelaOhakim",
                    Password = "Shicencellovewedismicallomumicin9",
                    Role = "caseWorker"
                },
                new()
                {
                    UserId = 3,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    UserName = "TisaBalogun",
                    Password = "Raingerencenalesmuctancissovisca3",
                    Role = "caseWorker"
                },
                new()
                {
                    UserId = 4,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    UserName = "KitwanaSolarin",
                    Password = "Ossaolyssalowlsonsancablernstern3",
                    Role = "caseWorker"
                },
                new()
                {
                    UserId = 5,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    UserName = "MadsTheBossMan",
                    Password = "Ferrari007JamesBondIsTheBest",
                    Role = "caseWorker"
                }
            });

            context.SaveChanges();
        }
    }

    private static void ClearDb(TelstarLogisticsContext context)
    {
        foreach (var id in context.Cities.Select(e => e.CityId))
        {
            var entity = new City { CityId = id };
            context.Cities.Attach(entity);
            context.Cities.Remove(entity);
        }

        foreach (var id in context.Users.Select(e => e.UserId))
        {
            var entity = new User { UserId = id };
            context.Users.Attach(entity);
            context.Users.Remove(entity);
        }

        foreach (var id in context.Routes.Select(e => e.RouteId))
        {
            var entity = new Route { RouteId = id };
            context.Routes.Attach(entity);
            context.Routes.Remove(entity);
        }

        context.SaveChanges();
    }
}