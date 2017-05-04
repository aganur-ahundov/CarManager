using System;
using System.ComponentModel.DataAnnotations;

namespace CarManager.Models
{
    public enum RouteStatus
    {
        Open,

        Close,

        InProgress,

        Cancel
    }

    public class DeliveryRoute
    {
        [Key]
        public int Id { get; set; }
        
        //Address of route end
        [Required]
        [Display(Name = "To")]
        public string DeliveryTo { get; set; }

        //Address of route start
        [Required(ErrorMessage = "This field is required")]
        [Display( Name = "From")]
        public string DeliveryFrom { get; set; }

        [Required]
        [Display( Name = "Date")]
        public DateTime DeliveryDate { get; set; }

        public DateTime Created { get; set; }

        public RouteStatus Status { get; set; }

        [Display( Name = "Transborder")]
        public bool IsTransborder { get; set; }


        public int? DriverId { get; set; }

        public Driver Driver { get; set; }
        
    }
}
