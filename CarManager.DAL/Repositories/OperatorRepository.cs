using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CarManager.DAL.Interfaces;
using CarManager.DAL.Context;
using CarManager.Models;



namespace CarManager.DAL.Repositories
{
    public class OperatorRepository : IRepository< Operator >
    {
        private CarContext context;

        public OperatorRepository( CarContext _context )
        {
            context = _context; 
        }

        public IEnumerable<Operator> GetAll()
        {
            return context.Operators;
        }

        public Operator Get( int id )
        {
            return context.Operators.Find( id );
        }

        public IEnumerable<Operator> Find( Func< Operator, Boolean > predicate )
        {
            return context.Operators.Where( predicate );
        }

        public void Create( Operator _new )
        {
            context.Operators.Add( _new );
        }

        public void Update( Operator _operator )
        {
            context.Entry( _operator ).State = EntityState.Modified;
        }

        public void Delete( int _id )
        {
            Operator deleteOperator = context.Operators.Find( _id );

            if ( deleteOperator != null )
                context.Entry( deleteOperator ).State = EntityState.Deleted;
        }

    }
}
