using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CarManager.DAL.Context;
using CarManager.DAL.Interfaces;
using CarManager.Models;




namespace CarManager.DAL.Repositories
{
    public class CarRepository : IRepository< Car >
    {
        private CarContext context;


        public CarRepository( CarContext _context )
        {
            context = _context;
        }


        public IEnumerable<Car> GetAll()
        {
            return context.Cars;
        }


        public Car Get( int _id )
        {
            return context.Cars.Find( _id );
        }


        public IEnumerable<Car> Find( Func<Car, Boolean> _predicate )
        {
            return context.Cars.Where( _predicate );
        }


        public void Create( Car _car )
        {
            context.Cars.Add( _car );
            context.SaveChanges();
        }

        public void Update( Car _car )
        {
            context.Entry( _car ).State = EntityState.Modified;
            context.SaveChanges();
        }


        public void Delete( int _id )
        {
            Car car = context.Cars.Find( _id );

            if ( car != null )
            {
                context.Entry( car ).State = EntityState.Deleted;
            }
        }
    }
}
