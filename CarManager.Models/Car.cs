﻿using System.ComponentModel.DataAnnotations;

namespace CarManager.Models
{
    public enum CarType
    {
        Truck,

        Trailer,

        Coupling
    }
    

    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Mark { get; set; }

        [Required]
        public string Model { get; set; }
        
        [Required]
        [Display( Name = "Carrying Capacity" )]
        public int CarryingCapacity { get; set; }

        public CarType Type { get; set; }

        [Display( Name = "Is broken" )]
        public bool IsBroken { get; set; }
 
    }
}
