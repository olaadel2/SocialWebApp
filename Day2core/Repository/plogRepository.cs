using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.Areas.Identity.Data;
using Day2core.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day2core.Repository
{
    public class plogRepository:IplogRepository
    {
        Day2coreContext db;
        public plogRepository(Day2coreContext db)
        {
            this.db = db;
        }
        public List<blog> getall()
        {
            return db.Blogs.ToList();
        }
        
        public blog getByid( int id)
        {
            return db.Blogs.Find(id);
        }

        public void add(blog b)
        {
            db.Blogs.Add(b);
            db.SaveChanges();
        }
        public void edit(blog b)
        {
            
                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();
            
        }
        public void delete(int id)
        {
            blog b = db.Blogs.Where(n => n.id == id).FirstOrDefault();
            db.Blogs.Remove(b);
           
           db.SaveChanges();
               

        }
    }
}
