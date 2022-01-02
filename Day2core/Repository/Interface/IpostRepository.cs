using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.DAL.Models;
using Day2core.Repository.IRepository;
using Day2core.ViewModel;

namespace Day2core.Repository
{
    public interface IpostRepository:IGenericRepository<post>
    {
        IOrderedQueryable<post> getall();
        post getByid(int id);
        List<post> getpostByuserid(string id);
        List<post> getpostBygroupid(int id);
       
        string GetcreatedBy(string id);
        byte[] GetImageFromDataBase(int id);
        List<post> getpostByfilter(filter filter);
        //List<post>getpostBydate(int id, DateTime? startdate, DateTime? enddate);
        //List<post>getpostByallfilter(int id, string title, DateTime? startdate, DateTime? enddate, List<string> usersid);
        //List<post>getpostByusers(int id, List<string> usersid);
    }
}
