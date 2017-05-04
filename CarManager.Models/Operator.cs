using System;
using System.Collections.Generic;
using System.Text;

namespace CarManager.Models
{
    public class Operator
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Requests, that operator selected ( Accepted/Rejected )
        public IEnumerable<Request> Requests { get; set; }

        //Appointed routes
        public IEnumerable<DeliveryRoute> Routes { get; set; }
        
    }
}
