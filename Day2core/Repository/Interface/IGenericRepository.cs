using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.Repository.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
       public int add(TEntity entity);
       public int delete(TEntity entity);
       public int edit(TEntity entity);
    }
}
