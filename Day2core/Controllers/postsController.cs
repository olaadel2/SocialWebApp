using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Day2core.Repository;
using System.Security.Claims;

namespace Day2core.Controllers
{
    public class postsController : Controller
    {
        IpostRepository p;
        IplogRepository b;
        public postsController(IpostRepository p ,IplogRepository b)
        {
            this.p = p;
            this.b = b;
        }

        public IActionResult Index()
        {
            try
            {
                List<post> posts = p.getall();
                if (posts == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(posts);
                }
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });
            }
           
        }

       
        [HttpPost]
        public IActionResult create( post s)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                s.date = DateTime.Now;
                s.user_Id = userId;
                if (ModelState.IsValid)
                {
                    int count = p.add(s);
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
            catch(Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });

            }

        }
        [HttpPost]
        public IActionResult createbygroup([FromQuery]int groupid, post post)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                post.date = DateTime.Now;
                post.user_Id = userId;
                post.group_id = groupid;
                if (ModelState.IsValid)
                {
                    int count = p.add(post);
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
            catch (Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });

            }

        }
        public IActionResult delete(int id)
        {
            try
            {
                int count = p.delete(id);
               
                if (count > 0)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    return Json(new { ok = false, message = "fail" });
                }
            }catch(Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });

            }

        }
        public IActionResult edit(int id)
        {

            try
            {
                post posts = p.getByid(id);
                if (posts == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(posts);
                }
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });
            }

        }
        [HttpPost]
        public IActionResult edit(post pos)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            pos.user_Id = userId;
            try
            {
                if (ModelState.IsValid)
                {
                    int count = p.edit(pos);
                    if (count > 0)
                    {
                        return RedirectToAction("index");
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
            catch(Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });

            }
        }
        public PartialViewResult dataformodel()
        {
            try
            {
                List<blog> blogs = b.getall();

                ViewBag.plog = new SelectList(blogs, "id", "name");

                return PartialView("_dataformodel");
            }
            catch (Exception ex)
            {
                return PartialView();
            }
           
            
        }
        public PartialViewResult dataofposts()
        {
            
            try
            {
                List<post> posts = p.getall();
                if (posts == null)
                {
                    return PartialView();
                }
                else
                {
                    return PartialView("_dataofposts", posts);
                }
            }
            catch (Exception ex)
            {
                return PartialView();
            }

        }
        public PartialViewResult getpostbygroup(int id)
        {
            try
            {
                List<post> posts = p.getpostBygroupid(id);
                if (posts.Count==0)
                {
                    return PartialView();
                }
                else
                {
                    return PartialView("_getpostbygroup", posts);
                }
            }
            catch (Exception ex)
            {
                return PartialView();
            }
        }
       
    }
}
