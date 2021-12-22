using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.Models
{
    public class blog
    {
        public blog()
        {
            Posts = new List<post>();
        }
        public int id { get; set; }

        public string name { get; set; }
        public string desc { get; set; }

        public virtual List<post> Posts { get; set; }
    }
}
