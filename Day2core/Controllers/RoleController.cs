using Day2core.Areas.Identity.Data;
using Day2core.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<ApplicationUser> userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
        public IActionResult AddroleTouser()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.users = userManager.Users.ToList();
            mymodel.roles = roleManager.Roles.ToList();
            return View(mymodel);
        }
        //public async Task<IActionResult> AddroleTouser(ApplicationUser user, string role)
        //{
        //    await userManager.AddToRoleAsync(user, role);
        //    return RedirectToAction("Index");
        //}
    }
}
