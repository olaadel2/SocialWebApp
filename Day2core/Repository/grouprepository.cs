using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.Areas.Identity.Data;
using Day2core.Data;
using Day2core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Day2core.Repository
{
    public class grouprepository:IgroupRepository
    {
        Day2coreContext db;
        
        public grouprepository(Day2coreContext db )
        {
            this.db = db;
           

        }
        List<group> IgroupRepository.getall()
        {
           var users= db.Users.AsQueryable().ToList();
            return db.Groups.ToList();
        }
       group IgroupRepository.getByid(int id)
        {
            return db.Groups.Find(id);
        }
        groupofuser IgroupRepository.getgroup(int groupid, string userid)
        {
            return db.Groupofusers.Where(n => n.GroupId == groupid && n.UserId == userid).FirstOrDefault();
        }
        int IgroupRepository.add(group p)
        {
            db.Groups.Add(p);
            return db.SaveChanges();
        }
        int IgroupRepository.delete(int id)
        {
            group p = db.Groups.Where(n => n.id == id).FirstOrDefault();
            db.Groups.Remove(p);
            return db.SaveChanges();
        }
        int IgroupRepository.edit(group p)
        {
            db.Entry(p).State = EntityState.Modified;
           return db.SaveChanges();
        }

        


        List<group> IgroupRepository.getByuserid(string id)
        {
            List<groupofuser> p = new List<groupofuser>();
            List<group> group_of_user = new List<group>();
            group_of_user = db.Groupofusers.Where(n => n.UserId == id).Select(c => c.Group).ToList();
            
            return group_of_user;
        }
        List<group> IgroupRepository.getgroupBynotuserid(string id)
        {
            List<groupofuser> p = new List<groupofuser>();
            List<group> group_of_user = new List<group>();

            //p = db.Groupofusers.Where(n => n.UserId == id).ToList();
            //foreach (var item in p)
            //{

            //    //group_of_user.Add(db.Groups.FirstOrDefault(n => n.id != item.GroupId));

            //}
            //group_of_user = db.Groupofusers.Where(n => n.UserId != id).Select(c => c.Group).ToList();

            var joinedGroupsIds = db.Groupofusers
                                  .Where(c => c.UserId == id)
                                  .Select(c => c.GroupId).ToList();

                 group_of_user=   db.Groups
                                    .Where(c => !joinedGroupsIds.Contains(c.id))
                                    .ToList();

            if (group_of_user.Count == 0)
            {
                group_of_user = db.Groups.ToList();
            }


            return group_of_user;
        }
        int IgroupRepository.addusertogroup(int group_id, string user_id)
        {
            groupofuser group = new groupofuser();
            group.GroupId = group_id;
            group.UserId = user_id;
            group.IsAccept = false;
            db.Groupofusers.Add(group);
            return db.SaveChanges();
        }


    }
}
