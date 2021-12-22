using Day2core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.Areas.Identity.Data
{
    public class ApplicationUser: IdentityUser
    {
   
        public virtual List<post> Posts { get; set; }
       

    }
}
