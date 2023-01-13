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

        if (!context.Bookings.Any())
        {
            context.Bookings.AddRange(new List<Booking>
            {
                new()
                {
                    BookingId = 1,
                    BookingRevenue = 1,
                    CargoCenterLocations = "Warsaw",
                    CustEmail = "test@gmail.com",
                    CustName = "a",
                    CustPhone = 5125513,
                    Handover = DateTime.Now,
                    Height= 30,
                    Length= 30,
                    ParcelType = "Live animals",
                    Recommended = false,
                    UserId= 2,
                    Weight = 30,
                    Width = 32,
                }
            });
        }

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
                    City1Id = 26,
                    City2Id = 9,
                    TransportType = "car",
                    Distance = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 9,
                    City2Id = 27,
                    TransportType = "car",
                    Distance = 6
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 27,
                    City2Id = 19,
                    TransportType = "car",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 27,
                    City2Id = 10,
                    TransportType = "car",
                    Distance = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 10,
                    City2Id = 11,
                    TransportType = "car",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 11,
                    City2Id = 33,
                    TransportType = "car",
                    Distance = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 10,
                    City2Id = 30,
                    TransportType = "car",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 10,
                    City2Id = 36,
                    TransportType = "car",
                    Distance = 7
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 10,
                    City2Id = 37,
                    TransportType = "car",
                    Distance = 2
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 10,
                    City2Id = 28,
                    TransportType = "car",
                    Distance = 8
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 28,
                    City2Id = 2,
                    TransportType = "car",
                    Distance = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 28,
                    City2Id = 1,
                    TransportType = "car",
                    Distance = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 1,
                    City2Id = 26,
                    TransportType = "car",
                    Distance = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 2,
                    City2Id = 21,
                    TransportType = "car",
                    Distance = 8
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 21,
                    City2Id = 15,
                    TransportType = "car",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 15,
                    City2Id = 3,
                    TransportType = "car",
                    Distance = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 15,
                    City2Id = 29,
                    TransportType = "car",
                    Distance = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 29,
                    City2Id = 36,
                    TransportType = "car",
                    Distance = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 30,
                    City2Id = 36,
                    TransportType = "car",
                    Distance = 7
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 30,
                    City2Id = 31,
                    TransportType = "car",
                    Distance = 6
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 31,
                    City2Id = 36,
                    TransportType = "car",
                    Distance = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 31,
                    City2Id = 32,
                    TransportType = "car",
                    Distance = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 32,
                    City2Id = 16,
                    TransportType = "car",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 16,
                    City2Id = 17,
                    TransportType = "car",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 17,
                    City2Id = 37,
                    TransportType = "car",
                    Distance = 2
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 17,
                    City2Id = 33,
                    TransportType = "car",
                    Distance = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 33,
                    City2Id = 14,
                    TransportType = "car",
                    Distance = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 32,
                    City2Id = 24,
                    TransportType = "car",
                    Distance = 10
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 17,
                    City2Id = 24,
                    TransportType = "car",
                    Distance = 6
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 34,
                    City2Id = 24,
                    TransportType = "car",
                    Distance = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 34,
                    City2Id = 14,
                    TransportType = "car",
                    Distance = 6
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 24,
                    City2Id = 35,
                    TransportType = "car",
                    Distance = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 35,
                    City2Id = 4,
                    TransportType = "car",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 35,
                    City2Id = 8,
                    TransportType = "car",
                    Distance = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 8,
                    City2Id = 24,
                    TransportType = "car",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 4,
                    City2Id = 7,
                    TransportType = "car",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 1,
                    City2Id = 20,
                    TransportType = "boat",
                    Distance = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 20,
                    City2Id = 21,
                    TransportType = "boat",
                    Distance = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 21,
                    City2Id = 15,
                    TransportType = "boat",
                    Distance = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 21,
                    City2Id = 6,
                    TransportType = "boat",
                    Distance = 10
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 15,
                    City2Id = 3,
                    TransportType = "boat",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 3,
                    City2Id = 22,
                    TransportType = "boat",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 3,
                    City2Id = 4,
                    TransportType = "boat",
                    Distance = 11
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 22,
                    City2Id = 4,
                    TransportType = "boat",
                    Distance = 9
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 6,
                    City2Id = 4,
                    TransportType = "boat",
                    Distance = 10
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 6,
                    City2Id = 7,
                    TransportType = "boat",
                    Distance = 9
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 7,
                    City2Id = 18,
                    TransportType = "boat",
                    Distance = 8
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 18,
                    City2Id = 24,
                    TransportType = "boat",
                    Distance = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 24,
                    City2Id = 14,
                    TransportType = "boat",
                    Distance = 8
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 14,
                    City2Id = 13,
                    TransportType = "boat",
                    Distance = 8
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 14,
                    City2Id = 25,
                    TransportType = "boat",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 11,
                    City2Id = 19,
                    TransportType = "boat",
                    Distance = 4
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 19,
                    City2Id = 26,
                    TransportType = "boat",
                    Distance = 5
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 26,
                    City2Id = 1,
                    TransportType = "boat",
                    Distance = 3
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 1,
                    City2Id = 2,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 1,
                    City2Id = 9,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 2,
                    City2Id = 15,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 2,
                    City2Id = 3,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 3,
                    City2Id = 12,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 3,
                    City2Id = 4,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 3,
                    City2Id = 9,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 4,
                    City2Id = 7,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 5,
                    City2Id = 6,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 6,
                    City2Id = 7,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 7,
                    City2Id = 16,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 7,
                    City2Id = 8,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 8,
                    City2Id = 17,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 7,
                    City2Id = 18,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 7,
                    City2Id = 13,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 9,
                    City2Id = 10,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 10,
                    City2Id = 16,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 10,
                    City2Id = 11,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 11,
                    City2Id = 19,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 11,
                    City2Id = 17,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 12,
                    City2Id = 4,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 13,
                    City2Id = 14,
                    TransportType = "plane",
                    Distance = 1
                },
                new()
                {
                    RouteId = rnd.Next(1, 9999999),
                    City1Id = 14,
                    City2Id = 17,
                    TransportType = "plane",
                    Distance = 1
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