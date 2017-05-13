using System;
using System.Collections.Generic;
using System.Data.Entity;
using CarManager.Models;

namespace CarManager.DAL.Context
{
    public class CarContext : DbContext
    {
        public DbSet<DeliveryRoute> Routes { get; set; }

        public DbSet<Operator> Operators { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Request> Requests { get; set; }
    }
}
