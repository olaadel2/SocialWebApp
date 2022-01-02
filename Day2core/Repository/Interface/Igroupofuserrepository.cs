using Day2core.DAL.Models;
using Day2core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.Repository
{
    interface Igroupofuserrepository
    {
      
        int delete(int groupid, string userid);
        int edit(groupofuser b);
        groupofuser getbyid(int groupid, string userid);
        List<Grouprequest> Requestuser();
        int addusertogroup(int group_id, string user_id);
    }
}
