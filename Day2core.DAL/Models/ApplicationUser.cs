
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.DAL.Models
{   
    public class ApplicationUser: IdentityUser
    {
   
        public virtual List<post> Posts { get; set; }
        


    }
}
