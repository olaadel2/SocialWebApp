using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Day2core.Areas.Identity.Data;
using Day2core.DAL.Models;
using Day2core.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Day2core.Repository
{
    public class postrepository : GenericRepository<post>,IpostRepository
    {
       
        Day2coreContext db;
        private readonly IMapper _mapper;
        public postrepository(Day2coreContext db,IMapper mapper):base(db)
        {
            this.db = db;
            this._mapper = mapper;
        }

        public IOrderedQueryable<post> getall()
        {

            // IOrderedQueryable<PostsView> posts = db.Posts.Where(n => n.group_id == null).Select(n => new PostsView(n)).ToList().AsQueryable<PostsView>().OrderBy(x => x.title);
            //IOrderedQueryable<PostsView> posts = db.Posts.Where(n => n.group_id == null).Select(n => _mapper.Map<post,PostsView>(n)).OrderBy(n => n.title);

            // IOrderedQueryable<PostsView> posts=db.Posts.Where(n => n.group_id == null).Select(n=>new PostsView {id=n.id,title=n.title,desc=n.desc,bref=n.bref, date=n.date, blog_id=n.blog_id,group_id=n.group_id,user_Id=n.user_Id,image=n.image,CreatedBy=n.ApplicationUser.UserName}).OrderBy(n=>n.title);
          IOrderedQueryable<post> posts = db.Posts.Where(n => n.group_id == null).Include(n=>n.ApplicationUser).AsQueryable().OrderBy(n=>n.title);

            return posts;
        }
        public post getByid(int id)
        {
          
            
            return db.Posts.Find(id);
        }

       

        List<post> IpostRepository.getpostBygroupid(int id)
        {
            return db.Posts.Where(n => n.group_id == id).ToList();
        }
        List<post> IpostRepository.getpostByfilter(filter filter)
        {

            var query= db.Posts.AsQueryable().Where(n=>n.group_id==filter.id);
            if (filter.title != null)
            {
                query = query.Where(n => n.title.Contains(filter.title) || n.desc.Contains(filter.title));
            }
            if (filter.startdate != null)
            {
                query = query.Where(n => n.date >= filter.startdate);
            }
            if (filter.enddate != null)
            {
                query = query.Where(n => n.date <= filter.enddate);
            }
            if (filter.usersid.Count != 0)
            {
                query = query.Where(n => filter.usersid.Contains(n.user_Id));
            }
            return query.ToList();
        }
       
        List<post> IpostRepository.getpostByuserid(string id)
        {
            return db.Posts.Where(n => n.user_Id == id).ToList();
        }

        string IpostRepository.GetcreatedBy(string id)
         {
            var user = db.Users.FirstOrDefault(n => n.Id == id);
            return user.UserName;
        }
         byte[] IpostRepository.GetImageFromDataBase(int id)
        {
            byte[]image = db.Posts.Where(n => n.id == id).Select(n=>n.image).FirstOrDefault();
            
            return image;
        }
    }
}
