using Day2core.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.ViewModel
{
    public class PostsView
    {
        public int id { get; set; }
        
        public string title { get; set; }
        public string bref { get; set; }
        public string desc { get; set; }
        public DateTime date { get; set; }
       
        public int? blog_id { get; set; }
       
        public int? group_id { get; set; }
      
        public string user_Id { get; set; }
        public string CreatedBy { get; set; }
        public byte[] image { get; set; }
        public IFormFile photo { get; set; }
        public string ProfilePicture { get; set; }
        //public PostsView()
        //{

        //}
        //public PostsView(post p)
        //{
        //    this.id = p.id;
        //    this.title = p.title;
        //    this.desc = p.desc;
        //    this.date = p.date;
        //    this.bref = p.bref;
        //    this.blog_id = p.blog_id;
        //    this.user_Id = p.user_Id;
        //    this.group_id = p.group_id;
        //    this.image = p.image;
        //    //this.CreatedBy = CreatedBy;

        //}
    }
}
