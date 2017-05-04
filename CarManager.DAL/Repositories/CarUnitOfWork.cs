using System;
using CarManager.DAL.Interfaces;
using CarManager.DAL.Context;
using CarManager.Models;


namespace CarManager.DAL.Repositories
{
    public class CarUnitOfWork : IUnitOfWork
    {
        private CarContext context = new CarContext();

        private OperatorRepository operatorRepository;

        private RouteRepository routeRepository;

        private DriverRepository driverRepository;


        public IRepository<Operator> Operators
        {
            get
            {
                if ( operatorRepository == null )
                    operatorRepository = new OperatorRepository( context );

                return operatorRepository;
            }
        }


        public IRepository<DeliveryRoute> Routes
        {
            get
            {
                if ( routeRepository == null )
                    routeRepository = new RouteRepository( context );

                return routeRepository;
            }
        }

        
        public IRepository<Driver> Drivers
        {
            get
            {
                if ( driverRepository == null )
                    driverRepository = new DriverRepository( context );

                return driverRepository;
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
