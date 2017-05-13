using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using CarManager.DAL.Context;
using CarManager.DAL.Identity;


[assembly: OwinStartup(typeof(CarManager.App_Start.Startup))]

namespace CarManager.App_Start
{
    public class Startup
    {
        public void Configuration( IAppBuilder app )
        {
            // настраиваем контекст и менеджер
            app.CreatePerOwinContext<ApplicationContext>( ApplicationContext.Create );
            app.CreatePerOwinContext<ApplicationUserManager>( ApplicationUserManager.Create );
            app.UseCookieAuthentication( new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString( "/Account/Login" ),
            });
        }
    }
}