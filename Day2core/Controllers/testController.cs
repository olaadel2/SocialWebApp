using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2core.Controllers
{
    public class testController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile photo)
        {
          var stream=  System.IO.File.Create($"attach/{photo.FileName}");
            photo.CopyTo(stream);

            return View();
        }
    }
}
