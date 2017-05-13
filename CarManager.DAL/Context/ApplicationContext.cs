using System;
using Microsoft.AspNet.Identity.EntityFramework;
using CarManager.Models.Identity;


namespace CarManager.DAL.Context
{
    public class ApplicationContext : IdentityDbContext< ApplicationUser >
    {
        public ApplicationContext() : base( "IdentityDb" ) { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}
