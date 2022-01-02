using Day2core.Areas.Identity.Data;
using Day2core.DAL.Models;
using Day2core.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.Repository
{
    public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity : class
    {
        Day2coreContext db;
        public GenericRepository(Day2coreContext db)
        {
            this.db = db;
        }
        public int add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            return db.SaveChanges();
        }

        public int delete(TEntity entity)
        {
            try
            {
                var prop = entity.GetType().GetProperty("IsDeleted");
                if (prop != null)
                {
                    prop.SetValue(entity, true);
                    db.Attach(entity);
                    db.Entry(entity).State = EntityState.Modified;
                    return 0;
                   
                }
                else
                {
                    db.Set<TEntity>().Remove(entity);
                    return db.SaveChanges();
                }
            }
            catch (Exception e) {
                return 0;
            }
            
        }

        public int edit(TEntity entity)
        {
            try
            {
                db.Set<TEntity>().Attach(entity);
                var entry = db.Entry(entity);
                entry.State = EntityState.Modified;
                return db.SaveChanges();
            }
            catch (Exception e) {
                return 0;

            }
        }
    }
}
