using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.Areas.Identity.Data;
using Day2core.DAL.Models;
using Day2core.Repository.IRepository;
using Day2core.ViewModel;

namespace Day2core.Repository
{
    interface IgroupRepository : IGenericRepository<group>
    {
        List<group> getall();
        group getByid(int id);
        List<group> getjoinedgroup(string id);
        List<group> getallgroups(string id);
        List<ApplicationUser> Getuserbygroup(int id);



    }
}
