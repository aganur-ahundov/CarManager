using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarManager.DAL.Repositories;
using CarManager.Models;


namespace CarManager.Controllers
{
    public class CarController : Controller
    {
        private CarUnitOfWork repository = new CarUnitOfWork();

        // GET: Car
        public ActionResult Index()
        {
            return View( repository.Cars.GetAll() );
        }

        [HttpGet]
        [Authorize( Roles = "admin" )]
        public ActionResult AddCar()
        {
            return View( "AddCar" );
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddCar( Car car )
        {
            car.IsFree = true;
            repository.Cars.Create( car );
            return View( "Index", repository.Cars.GetAll() );
        }


        [HttpGet]
        [Authorize( Roles = "admin" )]
        public ActionResult EditCar( int? id )
        {
            if (id == null)
                return HttpNotFound();

            Car car = repository.Cars.Get( (int)id );

            if ( car != null )
                return View( "EditCar", car );

            return HttpNotFound();
        }


        [HttpPost]
        [Authorize( Roles = "admin" )]
        public ActionResult EditCar( Car car )
        {
            repository.Cars.Update( car );
            return View( "Index", repository.Routes.GetAll() );
        }
        
    }
}