using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LinkedIn.Data;
using System.IO;
using LinkedIn.Models;
using System.Collections.Generic;

namespace LinkedIn.Controllers
{
    public class JobSeekerController : Controller 
    {
        private readonly AppDb _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public JobSeekerController(AppDb db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }


        public IActionResult Apply(JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;


                string upload = webRootPath + WC.image;
                string filename = Guid.NewGuid().ToString();
                string extesnsion = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(upload, filename + extesnsion), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                jobSeeker.Resume = filename + extesnsion;
                _db.jobSeekers.Add(jobSeeker);
                _db.SaveChanges();
                return RedirectToAction("Thanks");
            }
            return View(jobSeeker);
        }


        public IActionResult Thanks()
        {
            TempData[SD.Success] = "Job Apply Successfully!";
            return View();
        }

       
    }
}
