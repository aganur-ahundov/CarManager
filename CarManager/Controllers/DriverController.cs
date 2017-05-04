using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarManager.DAL.Repositories;
using CarManager.Models;

namespace CarManager.Controllers
{
    public class DriverController : Controller
    {
        private CarUnitOfWork repository = new CarUnitOfWork();

        // GET: Driver
        public ActionResult Index()
        {
            return View( repository.Drivers.GetAll() );
        }

        public ActionResult DriverDetails( int? id )
        {
            if ( id == null )
                return HttpNotFound();

            Driver driver = repository.Drivers.Get( (int)id );

            if ( driver == null )
                return HttpNotFound();
            
            return View( "DriverDetails", driver );
        }


        //public ActionResult AddDriver()
        //{

        //}
    }
}