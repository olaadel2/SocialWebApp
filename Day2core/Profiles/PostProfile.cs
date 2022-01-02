using AutoMapper;
using Day2core.ViewModel;
using Day2core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.Profiles
{
    public class PostProfile:Profile
    {
        public PostProfile()
        {
            CreateMap<post,PostsView>().ReverseMap();
        }
      
    }
}
