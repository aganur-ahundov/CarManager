using System;
using CarManager.DAL.Interfaces;
using CarManager.DAL.Context;
using CarManager.Models;


namespace CarManager.DAL.Repositories
{
    public class CarUnitOfWork : IUnitOfWork
    {
        private CarContext context = new CarContext();

        private OperatorRepository m_operators;

        private RouteRepository m_routes;

        private DriverRepository m_drivers;

        private RequestRepository m_requests;


        public IRepository<Operator> Operators
        {
            get
            {
                if ( m_operators == null )
                    m_operators = new OperatorRepository( context );

                return m_operators;
            }
        }


        public IRepository<DeliveryRoute> Routes
        {
            get
            {
                if ( m_routes == null )
                    m_routes = new RouteRepository( context );

                return m_routes;
            }
        }

        
        public IRepository<Driver> Drivers
        {
            get
            {
                if ( m_drivers == null )
                    m_drivers = new DriverRepository( context );

                return m_drivers;
            }
        }

        public IRepository<Request> Requests
        {
            get
            {
                if ( m_requests == null )
                    m_requests = new RequestRepository( context );

                return m_requests;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }


        private bool disposed = false;

        public virtual void Dispose( bool disposing )
        {
            if( !this.disposed )
            {
                if( disposing )
                {
                    context.Dispose();
                }

                this.disposed = true;
            }
        }


        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

    }
}
