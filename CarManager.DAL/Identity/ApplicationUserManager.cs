using System;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using CarManager.Models.Identity;
using CarManager.DAL.Context;


namespace CarManager.DAL.Identity
{
    public class ApplicationUserManager : UserManager< ApplicationUser >
    {
        public ApplicationUserManager( IUserStore<ApplicationUser> store ) //storage object
            : base( store )
        {
        }

        public static ApplicationUserManager Create( IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context )
        {
            ApplicationContext db = context.Get< ApplicationContext >();
            ApplicationUserManager manager = new ApplicationUserManager( new UserStore<ApplicationUser>( db ));
            return manager;
        }
    }
}
