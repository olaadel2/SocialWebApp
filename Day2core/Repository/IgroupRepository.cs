using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.Models;

namespace Day2core.Repository
{
    interface IgroupRepository
    {
        List<group> getall();
        group getByid(int id);
        List<group> getByuserid(string id);
        List<group> getgroupBynotuserid(string id);
        int addusertogroup(int group_id, string user_id);
        int add(group b);
        int delete(int id);
        int edit(group b);
        groupofuser getgroup(int groupid, string userid);
    }
}
