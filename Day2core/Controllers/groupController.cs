using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Day2core.Repository;
using Day2core.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AutoMapper;
using Day2core.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;

namespace Day2core.Controllers
{
    
    
    public class groupController : Controller
    {
       
        IgroupRepository grouprepository;
        Igroupofuserrepository groupuserrepository;
        private readonly IMapper _mapper;
        UserManager<ApplicationUser> userManager;
        public groupController(grouprepository grouprepository, groupofuserrepository groupuserrepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.grouprepository = grouprepository;
            this.groupuserrepository = groupuserrepository;
            this._mapper = mapper;
            this.userManager = userManager;

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Getgroups()
        {
            return View(grouprepository.getall());
        }
        [Authorize(Roles = "Admin")]
        public IActionResult create()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult create(group g)
        {
           
            try
            {
                int count = grouprepository.add(g);

                if (count > 0)
                {
                    return Json(new { ok = true, message = "success" });
                }
                else
                {
                    return Json(new { ok = false, message = "fail" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });
            }
      

        }
        [Authorize(Roles = "Admin")]
        public IActionResult edit(int id)
        {

            return View(grouprepository.getByid(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult edit(group b)
        {
            if (ModelState.IsValid)
            {
                grouprepository.edit(b);
                return RedirectToAction("Getgroups");

            }
            return View(b);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult delete(group g)
        {
            grouprepository.delete(g);
            return Json(new { Ok = true, Message = "succes" });
        }
    
       public IActionResult Index(int id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.users = grouprepository.Getuserbygroup(id);
            mymodel.group = grouprepository.getByid(id);
            //List<GroupsView> g = grouprepository.Getuserbygroup(id);
            return View(mymodel);
           
        }
        public IActionResult Joinedgroup()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
           
            List<group> groups = grouprepository.getjoinedgroup(userId);
            List<GroupsView> groupsviews = new List<GroupsView>();
            foreach (var item in groups)
            {
                GroupsView groupmap = _mapper.Map<GroupsView>(item);
                groupofuser usersofgroup = groupuserrepository.getbyid(item.id, userId);
                if (usersofgroup != null)
                {
                    if (usersofgroup.status ==(int)Status.Accepted)
                    {
                       
                        groupmap.status = "Accepted";
                        groupsviews.Add(groupmap);
                       
                       

                    }
                    else
                    {
                        groupmap.status = "Pending";
                        groupsviews.Add(groupmap);

                       
                    }

                }
                else
                {
                    return View();
                }
            }
            return View(groupsviews);

        }
        public IActionResult Allgroups()//rename
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<group> groups = grouprepository.getallgroups(userId);
           
            return View(groups);
        }
        [HttpPost]
        public IActionResult AdduserTogroup(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int count= groupuserrepository.addusertogroup(id, userId);
            if (count > 0)
            {
                return Json(new { ok = true, message = "succes" });
            }
            else
            {
                return Json(new { ok = false, message = "succes" });

            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Requestuser()
        {
           
            List<Grouprequest> groupofusers = groupuserrepository.Requestuser();
            if (groupofusers.Count ==0)
            {
                return View();
            }
            else
            {
                return View(groupofusers);

            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Acceptrequest(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            groupofuser groupofuser = groupuserrepository.getbyid(id, userId);
            groupofuser.status = (int)Status.Accepted;
            if (ModelState.IsValid)
            {
                int count = groupuserrepository.edit(groupofuser);
                if (count > 0)
                {
                    return Json(new { ok = true, message = "success" });
                }
                else
                {
                    return Json(new { ok = false, message = "fail" });
                }


            }
            else
            {
                return Json(new { ok = false, message = "fail" });

            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rejectrequest(int id)
        {


            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int count = groupuserrepository.delete(id,userId);
                if (count > 0)
                {
                    return Json(new { ok = true, message = "success" });
                }
                else
                {
                    return Json(new { ok = false, message = "fail" });
                }


          
        }


    }
}
