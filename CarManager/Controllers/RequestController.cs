using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarManager.DAL.Repositories;
using CarManager.Models;


namespace CarManager.Controllers
{
    public class RequestController : Controller
    {
        private CarUnitOfWork repository = new CarUnitOfWork();
        

        public ActionResult Index()
        {
            return View( repository.Requests.GetAll() );
        }


        [HttpGet]
        [Authorize( Roles = "admin, driver")]
        public ActionResult AddRequest()
        {
            return View( "AddRequest" );
        }


        [HttpPost]
        [Authorize(Roles = "admin, driver")]
        public ActionResult AddRequest( Request request )
        {
            if( !repository.Drivers.GetAll().Any( d => d.LicenseNumber == request.DriverLicenseNumber ) )
            {
                ModelState.AddModelError( "", "This license number is not exist!" );
                return View( "AddRequest" );
            }

            repository.Requests.Create( request );
            return View( "Index", repository.Requests.GetAll() );

        }
    }
}