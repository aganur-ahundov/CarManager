using System;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using CarManager.DAL.Identity;
using CarManager.Models.Identity;



namespace CarManager.Controllers
{
    public class AccountController : Controller
    {
        [Authorize(Roles = "admin")]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Register( RegisterModel model )
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.Name, Year = model.Year };

                if( UserManager.FindByEmail( model.Email ) != null )
                {
                    ModelState.AddModelError( "", "User with this email has been registrated" );
                    return View(model);
                }

                IdentityResult result = await UserManager.CreateAsync( user, model.Password );

                if ( result.Succeeded )
                {
                    UserManager.AddToRole( user.Id, Enum.GetName( typeof(Roles), model.Role ).ToLower() );
                    return RedirectToAction( "Login", "Account" );
                }
                else
                {
                    foreach ( string error in result.Errors )
                    {
                        ModelState.AddModelError( "", error );
                    }
                }
            }

            return View(model);
        }


        


        public ActionResult Login( string returnUrl )
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login( LoginModel model, string returnUrl )
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindAsync( model.UserName, model.Password );   //try to get user (FindAsync)
                if (user == null)  //validation
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync( user, DefaultAuthenticationTypes.ApplicationCookie );  // for authention

                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn( new AuthenticationProperties
                    {
                        IsPersistent = true  //save authentification data in a browser ( even browser will be closed )
                    }
                    , claim );

                    if ( String.IsNullOrEmpty(returnUrl) )
                        return RedirectToAction( "Index", "Route" );//return RedirectToAction( "Index", "Home" );


                    return Redirect( returnUrl );
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }


        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction( "Login" );
        }


        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }


        //Manage Login in the site ( IAuthenticationManager has SignIn() and SignOut() )
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}