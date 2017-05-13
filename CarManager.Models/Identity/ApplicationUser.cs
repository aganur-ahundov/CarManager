using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarManager.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }
    }
}
