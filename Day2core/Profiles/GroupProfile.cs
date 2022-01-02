using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Day2core.DAL.Models;
using Day2core.ViewModel;


namespace Day2core.Profiles
{
    public class GroupProfile:Profile
    {
        public GroupProfile()
        {
            CreateMap<group, GroupsView>();
        }
    }
}
