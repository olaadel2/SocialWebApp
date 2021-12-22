using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Day2core.Repository;
using Day2core.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace Day2core.Controllers
{
    public class groupController : Controller
    {
        IgroupRepository g;
        public groupController(grouprepository g)
        {
            this.g = g;
        }
        public IActionResult Index(int id)
        {
            group group = g.getByid(id);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            groupofuser usersofgroup = g.getgroup(id, userId);
            if (usersofgroup != null)
            {
                if (usersofgroup.IsAccept == true)
                {
                    ViewBag.group =null;
                    return View(group);

                }
                else
                {
                    ViewBag.group = "Not Accept";
                    return View(group);
                }

              
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult getByuserid()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<group> groups = g.getByuserid(userId);

            ViewBag.group = new SelectList(groups, "id", "title");
            return View();
        }
        public IActionResult getBygroupnotuserid()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<group> groups = g.getgroupBynotuserid(userId);

            ViewBag.group = new SelectList(groups, "id", "title");
            return View();
        }
        [HttpPost]
        public IActionResult adduser(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int count=g.addusertogroup(id, userId);
            if (count > 0)
            {
                return Json(new { ok = true, message = "succes" });
            }
            else
            {
                return Json(new { ok = false, message = "succes" });

            }
        }
    }
}
