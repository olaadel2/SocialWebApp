using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.Data;
using Day2core.Models;
using Microsoft.EntityFrameworkCore;

namespace Day2core.Repository
{
    public class postrepository:IpostRepository
    {
       
        Day2coreContext db;
        public postrepository(Day2coreContext db)
        {
            this.db = db;
        }

        public List<post> getall()
        {
            return db.Posts.ToList();
        }
        public post getByid(int id)
        {
          
            
            return db.Posts.Find(id);
        }

        public int add (post p)
        {
            db.Posts.Add(p);
            return db.SaveChanges();
        }

        public int delete(int id)
        {
            post p = db.Posts.Where(n => n.id == id).FirstOrDefault();
            db.Posts.Remove(p);
            return db.SaveChanges();
        }
        public int edit(post p)
        {

            db.Entry(p).State = EntityState.Modified;
            return db.SaveChanges();

        }

        List<post> IpostRepository.getpostBygroupid(int id)
        {
            return db.Posts.Where(n => n.group_id == id).ToList();
        }

        List<post> IpostRepository.getpostByuserid(string id)
        {
            return db.Posts.Where(n => n.user_Id == id).ToList();
        }
    }
}
