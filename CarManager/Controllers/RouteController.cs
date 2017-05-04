using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarManager.DAL.Repositories;
using CarManager.Models;


namespace CarManager.Controllers
{
    public class RouteController : Controller
    {
        private CarUnitOfWork repository = new CarUnitOfWork();

        // GET: Route
        public ActionResult Index()
        {
            return View( repository.Routes.GetAll() );
        }

        [HttpGet]
        public ActionResult EditRoute( int? id )
        {
            if ( id == null )
                return HttpNotFound();

            DeliveryRoute editRoute = repository.Routes.Get( (int)id );

            if ( editRoute != null )
                return View( "EditRoute", editRoute );

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditRoute( DeliveryRoute route )
        {
            repository.Routes.Update( route );
            return View( "Index", repository.Routes.GetAll() );
        }

        [HttpGet]
        public ActionResult AddDeliveryRoute()
        {
            return View( "AddDeliveryRoute" ); ////HERE
        }

        [HttpPost]
        public ActionResult AddDeliveryRoute( DeliveryRoute route )
        {
            repository.Routes.Create( route );
            return View( "Index", repository.Routes.GetAll() );

        }
    }
}