using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CarManager.DAL.Interfaces;
using CarManager.Models;
using CarManager.DAL.Context;


namespace CarManager.DAL.Repositories
{
    public class RouteRepository : IRepository<DeliveryRoute>
    {
        private CarContext context;

        public RouteRepository( CarContext _context )
        {
            context = _context;
        }

        public IEnumerable<DeliveryRoute> GetAll()
        {
            return context.Routes;
        }

        public DeliveryRoute Get( int _id )
        {
            return context.Routes.Find( _id );
        }

        public IEnumerable<DeliveryRoute> Find( Func<DeliveryRoute, Boolean> _predicate )
        {
            return context.Routes.Where( _predicate );
        }

        public void Create( DeliveryRoute _route )
        {
            _route.Created = DateTime.UtcNow;
            context.Routes.Add( _route );
            context.SaveChanges();
        }

        public void Update( DeliveryRoute _route )
        {
            context.Entry( _route ).State = EntityState.Modified;
        }

        public void Delete( int _id )
        {
            DeliveryRoute route = context.Routes.Find( _id );
             
            if( route != null )
            {
                context.Entry( route ).State = EntityState.Deleted;
            }
        }
    }
}
