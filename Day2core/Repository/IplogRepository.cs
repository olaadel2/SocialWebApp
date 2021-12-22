using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.Models;

namespace Day2core.Repository
{
    public interface IplogRepository
    {
        List<blog> getall();
        blog getByid(int id);
        void add(blog b);
        void delete(int id);
        void edit(blog b);
    }
}
