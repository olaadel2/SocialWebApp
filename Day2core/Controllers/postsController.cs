using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2core.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Day2core.Repository;
using System.Security.Claims;
using Day2core.ViewModel;
using AutoMapper;
using ReflectionIT.Mvc.Paging;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
namespace Day2core.Controllers
{
    public class postsController : Controller
    {
        IpostRepository postrepository;
        IplogRepository plogrepository;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;
        
        public postsController(IpostRepository postrepository, IplogRepository plogrepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.postrepository = postrepository;
            this.plogrepository = plogrepository;
            this._mapper = mapper;
            this._webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int pageIndex)
        {

            return View();
           
        }

       
        [HttpPost]
        public IActionResult create(PostsView s)
        {
            post post = new post();
            
            try
            {
                string photoname=UploadedFile(s);
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
               post= _mapper.Map<post>(s);
               
           
                post.date = DateTime.Now;
                post.user_Id = userId;
                post.ProfilePicture = photoname;
                if (ModelState.IsValid)
                {
                    int count = postrepository.add(post);
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
                    //return View();

                }
            }
            catch(Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });

            }

        }
        private string UploadedFile(PostsView model)
        {
            string uniqueFileName = null;

            if (model.photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "attach");
                uniqueFileName =  model.photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.photo.CopyTo(fileStream);
                }
                
            }
            return uniqueFileName;
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
                    int count = postrepository.add(post);
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
        public IActionResult delete(post p)
        {
            try
            {
                int count = postrepository.delete(p);
               
                if (count > 0)
                {
                    return Json(new { ok = true, message = "success" });
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
        public PartialViewResult edit(int id)
        {

            try
            {
                post post = postrepository.getByid(id);
                PostsView postsviews = _mapper.Map<PostsView>(post);
                if (post == null)
                {
                    return PartialView();
                }
                else
                {
                    return PartialView("_edit",postsviews);
                }
            }
            catch (Exception ex)
            {
                return PartialView();
            }

        }
        [HttpPost]
        public IActionResult edit(post post)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            post.user_Id = userId;
            try
            {
                if (ModelState.IsValid)
                {
                    int count = postrepository.edit(post);
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
        public PartialViewResult dataformodel()
        {
            try
            {
                List<blog> blogs = plogrepository.getall();

                ViewBag.plog = new SelectList(blogs, "id", "name");

                return PartialView("_dataformodel");
            }
            catch (Exception ex)
            {
                return PartialView();
            }
           
            
        }
        public async Task<PartialViewResult> dataofposts(int page)
        {

            try
            {


                IOrderedQueryable<post> posts = postrepository.getall();

                //foreach (var item in posts)
                //{
                //    item.CreatedBy = postrepository.GetcreatedBy(item.user_Id);
                //}
                var model = await PagingList<post>.CreateAsync(posts, 2, page);

                if (model.Count == 0)
                {
                    return PartialView();
                }
                else
                {
                    return PartialView("_dataofposts", model);
                }
                
            }
            catch (Exception ex)
            {
                return PartialView();
            }
   
        }
       
        public PartialViewResult getpostbygroup(filter filter)
        {
            try
            {
                List<post> posts =postrepository.getpostByfilter(filter);
                

                List<PostsView> postsviews = new List<PostsView>();
                foreach (var item in posts)
                {
                    postsviews.Add(_mapper.Map<PostsView>(item));
                    
                }
                
                return PartialView("_getpostbygroup", postsviews);
              
            }
            catch (Exception ex)
            {
                return PartialView();
            }
        }
        //public ActionResult RetrieveImage(int id)
        //{
        //    ///upload bu byte
        //    //    if (photo != null)
        //    //   {
        //    //    if (photo.Length > 0)
        //    //    {
        //    //        //Getting FileName
        //    //        var fileName = Path.GetFileName(photo.FileName);
        //    //        //Getting file Extension
        //    //        var fileExtension = Path.GetExtension(fileName);
        //    //        // concatenating  FileName + FileExtension
        //    //        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);


        //    //        using (var target = new MemoryStream())
        //    //        {
        //    //            photo.CopyTo(target);
        //    //            post.image = target.ToArray();
        //    //        }
        //    //    }
        //    //}
        //    byte[] photo = postrepository.GetImageFromDataBase(id);
        //    if (photo != null)
        //    {
        //        return File(photo, "image/jpg");
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

    }
}
