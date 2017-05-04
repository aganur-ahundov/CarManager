using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CarManager.Models
{
    public enum DriverStatus
    {
        OnRoute,

        Available,

        NotAvailable,

        WaitForConfirm
    }


    public class Driver
    {
        [Key]
        public int Id { get; set; }

        [Display( Name = "License")]
        public string LicenseNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
        

        public DriverStatus Status { get; set; }

        public virtual IEnumerable<DeliveryRoute> RouteHistory { get; set; }

        //public DeliveryRoute CurrentRoute { get; set; }

        //public Request Request { get; set; }
    }
}
