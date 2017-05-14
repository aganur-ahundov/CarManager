using System;
using System.Web.Mvc;
using System.Linq;
using CarManager.DAL.Repositories;
using CarManager.Models;


namespace CarManager.Controllers
{
    public class RouteController : Controller
    {
        private CarUnitOfWork repository = new CarUnitOfWork();


        [Authorize(Roles = "admin, operator")]
        public ActionResult Index()
        {
            return View( repository.Routes.GetAll() );
        }


        [HttpGet]
        [Authorize(Roles = "admin, operator")]
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
        [Authorize( Roles = "admin, operator" )]
        public ActionResult EditRoute( DeliveryRoute route )
        {
            repository.Routes.Update( route );
            return View( "Index", repository.Routes.GetAll() );
        }


        [HttpGet]
        [Authorize( Roles = "admin, operator" )]
        public ActionResult AddDeliveryRoute()
        {
            return View( "AddDeliveryRoute" ); 
        }


        [HttpPost]
        [Authorize( Roles = "admin, operator" )]
        public ActionResult AddDeliveryRoute( DeliveryRoute route )
        {
            repository.Routes.Create( route );
            return View( "Index", repository.Routes.GetAll() );

        }

        
        public ActionResult SortRoutesById() ///CHANGE HERE AND ALL BRUNCH
        {
            return PartialView( "DeliveryRoutesList", repository.Routes.GetAll().OrderBy( r => r.Id ));
        }


        public ActionResult SortRoutesByCreatedTime()
        {
            return PartialView( "DeliveryRoutesList", repository.Routes.GetAll().OrderBy( r => r.Created ));
        }

        public ActionResult SortRoutesByStatus()
        {
            return PartialView( "DeliveryRoutesList", repository.Routes.GetAll().OrderBy( r => r.Status ));
        }
        
    }
}