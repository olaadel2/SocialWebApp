using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.ViewModel
{
    public class filter
    {
        public filter()
        {
            usersid = new List<string>();
        }
        public int id { get; set; }
        public string title { get; set; }
        public DateTime? startdate { get; set; }

        public DateTime? enddate { get; set; }
        public List<string> usersid { get; set; }
    }
}
