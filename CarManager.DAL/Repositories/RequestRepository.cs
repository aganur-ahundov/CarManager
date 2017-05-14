using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CarManager.Models;
using CarManager.DAL.Context;
using CarManager.DAL.Interfaces;

namespace CarManager.DAL.Repositories
{
    public class RequestRepository : IRepository<Request>
    {
        private CarContext context;

        public RequestRepository( CarContext _context )
        {
            context = _context;
        }

        public IEnumerable<Request> GetAll()
        {
            return context.Requests.Include( r => r.Car );
        }

        public Request Get( int _id )
        {
            return context.Requests.Find( _id );
        }

        public IEnumerable<Request> Find( Func<Request, Boolean> _predicate )
        {
            return context.Requests.Where( _predicate );
        }

        public void Create( Request _request )
        {
            _request.Created = DateTime.UtcNow;
            context.Requests.Add( _request );
            context.SaveChanges();
        }

        public void Update( Request _request )
        {
            context.Entry( _request ).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete( int _id )
        {
            Request Request = context.Requests.Find( _id );

            if ( Request != null )
            {
                context.Entry( Request ).State = EntityState.Deleted;
            }
        }
    }
}
