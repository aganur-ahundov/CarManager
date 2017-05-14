using System;
using System.ComponentModel.DataAnnotations;

namespace CarManager.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string DriverName { get; set; }
        
        
        [Required]
        [Display(Name = "Car Type")]
        public CarType CarType { get; set; }

        [Required]
        [Display(Name = "Carrying Capacity")]
        public int CarryingCapacity { get; set; }


        public DateTime Created { get; set; }


        public virtual Car Car { get; set; }
    }
}
