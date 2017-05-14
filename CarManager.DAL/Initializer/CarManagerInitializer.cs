using System;
using System.Linq;
using System.Data.Entity;
using CarManager.DAL.Context;
using CarManager.Models;


namespace CarManager.DAL.Initializer
{
    public class CarManagerInitializer : /*DropCreateDatabaseIfModelChanges<CarContext>*/  DropCreateDatabaseAlways<CarContext>
    {
        protected override void Seed( CarContext _context )
        {
            _context.Operators.Add(new Operator { Name = "Jax" });

            AddDrivers(_context);
            AddDeliveryRoutes(_context);

            _context.Cars.Add( new Car { Mark = "Mers", Model = "1883", CarryingCapacity = 4800, Weight = 8000, Type = CarType.Truck, Year = 1989, IsBroken = false, IsFree = true } );
            _context.Cars.Add( new Car { Mark = "Benz", Model = "1993", CarryingCapacity = 5800, Weight = 8500, Type = CarType.Truck, Year = 1989, IsBroken = false, IsFree = true } );
            _context.Cars.Add( new Car { Mark = "Coip", Model = "83", CarryingCapacity = 3800, Weight = 5000, Type = CarType.Coupling, Year = 1989, IsBroken = false, IsFree = true } );
            _context.Cars.Add( new Car { Mark = "Trail", Model = "013", CarryingCapacity = 6800, Weight = 9000, Type = CarType.Trailer, Year = 2003, IsBroken = false, IsFree = true } );
            _context.SaveChanges();

            base.Seed(_context);
        }

        private static void AddDrivers(CarContext _context)
        {
            _context.Drivers.Add(new Driver { Name = "Alex", Age = 27, Status = DriverStatus.Available });
            _context.Drivers.Add(new Driver { Name = "Nick", Age = 32, Status = DriverStatus.OnRoute });
            _context.Drivers.Add(new Driver { Name = "Max", Age = 41, Status = DriverStatus.Available });
            _context.Drivers.Add(new Driver { Name = "Alex", Age = 27, Status = DriverStatus.Available });
            _context.Drivers.Add(new Driver { Name = "Daril", Age = 30, Status = DriverStatus.Available });
            _context.SaveChanges();
        }

        private static void AddDeliveryRoutes(CarContext _context)
        {
            _context.Routes.Add( new DeliveryRoute { DeliveryFrom = "Kharkov", DeliveryTo = "Kiev", DeliveryDate = new DateTime(2017, 5, 3), Created = DateTime.UtcNow, IsTransborder = false, Status = RouteStatus.Open, DriverId = _context.Drivers.ToArray()[3].Id });
            _context.Routes.Add( new DeliveryRoute { DeliveryFrom = "Kharkov", DeliveryTo = "Moscow", DeliveryDate = new DateTime(2017, 5, 13), Created = DateTime.UtcNow, IsTransborder = true, Status = RouteStatus.Close, DriverId = _context.Drivers.ToArray()[3].Id });
            _context.Routes.Add( new DeliveryRoute { DeliveryFrom = "Kiev", DeliveryTo = "Lviv", DeliveryDate = new DateTime(2017, 5, 30), Created = DateTime.UtcNow, IsTransborder = false, Status = RouteStatus.InProgress, DriverId = _context.Drivers.ToArray()[4].Id });
            _context.Routes.Add( new DeliveryRoute { DeliveryFrom = "Lviv", DeliveryTo = "Krakov", DeliveryDate = new DateTime(2017, 5, 23), Created = DateTime.UtcNow, IsTransborder = true, Status = RouteStatus.Open , DriverId =  _context.Drivers.ToArray()[4].Id });

            _context.SaveChanges();
        }
    }
}
