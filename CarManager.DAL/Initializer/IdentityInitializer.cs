using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using CarManager.DAL.Identity;
using CarManager.DAL.Context;
using CarManager.Models.Identity;


namespace CarManager.DAL.Initializer
{
    public class IdentityInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext> /*DropCreateDatabaseAlways<ApplicationContext>*/
    {
        protected override void Seed( ApplicationContext context )
        {
            var userManager = new ApplicationUserManager( new UserStore<ApplicationUser>(context) );

            var roleManager = new RoleManager<IdentityRole>( new RoleStore<IdentityRole>(context) );

            // создаем две роли
            var admin_role = new IdentityRole { Name = "admin" };
            var user_role = new IdentityRole { Name = "user" };
            var operator_role = new IdentityRole { Name = "operator" };
            var driver_role = new IdentityRole { Name = "driver" };


            // добавляем роли в бд
            roleManager.Create(admin_role);
            roleManager.Create(user_role);
            roleManager.Create(operator_role);
            roleManager.Create(driver_role);


            CreateAdmin( userManager, admin_role, user_role );
            create_user( userManager, user_role, "User1", "user1@gmail.com", "111111" );
            create_user( userManager, operator_role, "Operator1", "operator1@gmail.com", "111111" );
            create_user( userManager, driver_role, "Driver1", "driver1@gmail.com", "111111");


            base.Seed(context);
        }



        private static void CreateAdmin(ApplicationUserManager userManager, IdentityRole role1, IdentityRole role2)
        {
            // создаем пользователей
            var admin = new ApplicationUser { Email = "admin@mail.ru", UserName = "Admin" };
            string password = "111111";
            var result = userManager.Create(admin, password);


            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
        }

        private static void create_user( ApplicationUserManager userManager, IdentityRole role, string name, string email, string password )
        {
            var user1 = new ApplicationUser { Email = email, UserName = name };
            var result = userManager.Create(user1, password);

            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(user1.Id, role.Name);
            }
        }

    }
}
