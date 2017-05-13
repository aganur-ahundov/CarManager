using System;
using System.ComponentModel.DataAnnotations;


namespace CarManager.Models.Identity
{

    public enum Roles
    {
        Operator,

        Driver
    }


    public class RegisterModel
    {
        [Required]
        [DataType( DataType.EmailAddress )]
        public string Email { get; set; }


        [Required]
        public string Name { get; set; }


        [Required]
        public int Year { get; set; }


        [Required]
        [DataType( DataType.Password )]
        public string Password { get; set; }


        [Required]
        [Compare( "Password", ErrorMessage = ( "Passwords don't match" ))]
        [DataType( DataType.Password )]
        public string PasswordConfirm { get; set; }

        [Required]
        public Roles Role { get; set; }
    }
}
