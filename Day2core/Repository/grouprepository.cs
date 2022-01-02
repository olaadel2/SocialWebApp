using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.Areas.Identity.Data;
using Day2core.Areas.Identity.Data;
using Day2core.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Day2core.ViewModel;

namespace Day2core.Repository
{
    public class grouprepository:GenericRepository<group>,IgroupRepository
    {
        Day2coreContext db;
        
        public grouprepository(Day2coreContext db ):base(db)
        {
            this.db = db;
           

        }
        List<group> IgroupRepository.getall()
        {
    
            return db.Groups.ToList();
        }
       group IgroupRepository.getByid(int id)
        {
            return db.Groups.Find(id);
        }
        

        List<group> IgroupRepository.getjoinedgroup(string id)
        {
           
            List<group> group_of_user = new List<group>();
            group_of_user = db.Groupofusers.Where(n => n.UserId == id).Select(c => c.Group).ToList();


            return group_of_user;
        }
        List<group> IgroupRepository.getallgroups(string id)
        {
           
            List<group> group_of_user = new List<group>();

            

            var joinedGroupsIds = db.Groupofusers.Where(c => c.UserId == id).Select(c => c.GroupId).ToList();

                 group_of_user=db.Groups.Where(c => !joinedGroupsIds.Contains(c.id)).ToList();



            return group_of_user;
        }
        List<ApplicationUser> IgroupRepository.Getuserbygroup(int id)
        {
         
            List<ApplicationUser> users = new List<ApplicationUser>();
           
            users = db.Groupofusers.Where(n => n.GroupId == id).Select(c =>c.ApplicationUser).ToList();


            return users;
        }

        public int add(group entity)
        {
            throw new NotImplementedException();
        }

        public int edit(group entity)
        {
            throw new NotImplementedException();
        }
    }
}
