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
            _context.Operators.Add( new Operator { Name = "Jax" } );

            
            _context.Drivers.Add( new Driver { Name = "Alex", Age = 27, LicenseNumber = "AX27891", Status = DriverStatus.Available } );
            _context.Drivers.Add( new Driver { Name = "Nick", Age = 32, LicenseNumber = "AP15191", Status = DriverStatus.OnRoute } );
            _context.Drivers.Add( new Driver { Name = "Max", Age = 41, LicenseNumber = "AX127764", Status = DriverStatus.Available } );
            _context.Drivers.Add( new Driver { Name = "Alex", Age = 27, LicenseNumber = "ZX168780", Status = DriverStatus.Available } );
            _context.Drivers.Add( new Driver { Name = "Daril", Age = 30, LicenseNumber = "IO274342", Status = DriverStatus.Available });

            _context.SaveChanges();
            AddDeliveryRoutes(_context);
            

            base.Seed(_context);
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
