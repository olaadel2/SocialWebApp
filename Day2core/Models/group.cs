﻿using Day2core.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.Models
{
    public class group
    {
        public group()
        {
            Posts = new List<post>();
        }
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public virtual List<post> Posts { get; set; }
        //public virtual List<ApplicationUser> ApplicationUsers { get; set; }
        


    }
}
