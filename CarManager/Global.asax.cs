using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using CarManager.DAL.Initializer;
using CarManager.DAL.Context;


namespace CarManager
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<CarContext> ( new CarManagerInitializer() );
            Database.SetInitializer<ApplicationContext>( new IdentityInitializer() );

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
