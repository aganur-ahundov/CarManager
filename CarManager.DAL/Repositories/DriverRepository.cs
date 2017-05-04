using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CarManager.DAL.Interfaces;
using CarManager.Models;
using CarManager.DAL.Context;


namespace CarManager.DAL.Repositories
{
    public class DriverRepository : IRepository< Driver >
    {
        private CarContext context;


        public DriverRepository ( CarContext _context )
        {
            context = _context;
        }


        public IEnumerable<Driver> GetAll()
        {
            return context.Drivers;
        }

        
        public Driver Get( int _id )
        {
            //with loop only!
            Driver driver = context.Drivers.Where( d => d.Id == _id ).First();

            if ( driver == null )
                return null;

            driver.RouteHistory = context.Routes.Where( r => r.DriverId == driver.Id );

            return driver;
        }


        public IEnumerable<Driver> Find( Func< Driver, bool > _predicate )
        {
            return context.Drivers.Where( _predicate );
        }


        public void Create( Driver _newDriver )
        {
            context.Drivers.Add( _newDriver );
            context.SaveChanges();
        }


        public void Update( Driver _driver )
        {
            context.Entry( _driver ).State = EntityState.Modified;
        }


        public void Delete( int _id )
        {
            Driver driver = context.Drivers.Find( _id );

            if ( driver != null )
            {
                context.Entry( driver ).State = EntityState.Deleted;
            }
        }
    }
}
