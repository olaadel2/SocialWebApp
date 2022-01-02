using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.Repository;
using Day2core.DAL.Models;
using Microsoft.AspNetCore.Authorization;

namespace Day2core.Controllers
{
    [Authorize(Roles = "Admin")]
    public class blogsController : Controller
    {
        IplogRepository blogrepository;
        IpostRepository postrepository;
        public blogsController(IplogRepository blogrepository,IpostRepository postrepository)
        {
            this.blogrepository = blogrepository;
            this.postrepository = postrepository;
        }
        public IActionResult Index()
        {
            return View(blogrepository.getall());
        }
        public IActionResult create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult create(blog b)
        {
            blogrepository.add(b);
            
            return Json(b);

        }
        public IActionResult edit(int id)
        {

            return View(blogrepository.getByid(id));
        }
        [HttpPost]
        public IActionResult edit(blog b)
        {
            if (ModelState.IsValid)
            {
                blogrepository.edit(b);
                return RedirectToAction("index");

            }
            return View(b);
        }
        public IActionResult delete(int id)
        {
            blogrepository.delete(id);
            return Json(new { Ok=true,Message="succes"});
        }
    }
}
