using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
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
            //if( !repository.Drivers.GetAll().Any( d => d.LicenseNumber == request.DriverLicenseNumber ) )
            //{
            //    ModelState.AddModelError( "", "This license number is not exist!" );
            //    return View( "AddRequest" );
            //}

            repository.Requests.Create( request );
            return View( "Index", repository.Requests.GetAll() );

        }


        public ActionResult ChooseCar( int? requestId )
        {

            if ( requestId == null )
                return HttpNotFound();

            Request request = repository.Requests.Get( (int)requestId );

            IEnumerable<Car> selectedCars 
                = repository.Cars.Find( c => c.IsFree == true 
                                        && c.IsBroken == false 
                                        && c.CarryingCapacity >= request.CarryingCapacity );

            ViewBag.requestId = requestId;

            return View( "CarList", selectedCars );
        }


        public ActionResult SelectCar( int? requestId, int? carId )
        {
            if ( requestId == null || carId == null)
                return HttpNotFound();

            Request request = repository.Requests.Get( (int) requestId );
            Car car = repository.Cars.Get( (int)carId );


            car.IsFree = false;
            request.Car = car;

            repository.Requests.Update( request );
            repository.Cars.Update( car );


            return View( "AddRequest" );  //MAIN PAGE
        }
    }
}