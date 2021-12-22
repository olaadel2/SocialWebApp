using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.Models;

namespace Day2core.Repository
{
    public interface IpostRepository
    {
        List<post> getall();
        post getByid(int id);
        List<post> getpostByuserid(string id);
        List<post> getpostBygroupid(int id);
        int add(post p);
        int delete(int id);
        int edit(post p);
    }
}
