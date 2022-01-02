using Day2core.Areas.Identity.Data;
using Day2core.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.ViewModel;

namespace Day2core.Repository
{
    public class groupofuserrepository : Igroupofuserrepository
    {
        Day2coreContext db;

        public groupofuserrepository(Day2coreContext db)
        {
            this.db = db;
        }


            int Igroupofuserrepository.delete(int groupid,string userid)
        {
            groupofuser p = db.Groupofusers.Where(n => n.GroupId == groupid && n.UserId == userid).FirstOrDefault();
            db.Groupofusers.Remove(p);
            return db.SaveChanges();
        }

        int Igroupofuserrepository.edit(groupofuser p)
        {
            db.Entry(p).State = EntityState.Modified;
            return db.SaveChanges();
        }

        groupofuser Igroupofuserrepository.getbyid(int groupid, string userid)
        {
            return db.Groupofusers.Where(n => n.GroupId == groupid && n.UserId == userid).FirstOrDefault();
        }

        List<Grouprequest> Igroupofuserrepository.Requestuser()
        {
            //List<groupofuser> groupofusers = new List<groupofuser>();


            List<Grouprequest> grouprequest = new List<Grouprequest>();


            grouprequest = db.Groupofusers.Where(c => c.status == 2).Select(c => new Grouprequest { id = c.GroupId, title = c.Group.title, username = c.ApplicationUser.UserName }).ToList();

          
            return grouprequest;
        }
        int Igroupofuserrepository.addusertogroup(int group_id, string user_id)
        {
            groupofuser group = new groupofuser();
            group.GroupId = group_id;
            group.UserId = user_id;
            group.status = 2;
            db.Groupofusers.Add(group);
            return db.SaveChanges();
        }
    }
}
