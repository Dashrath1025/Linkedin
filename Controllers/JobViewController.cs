using LinkedIn.Data;
using LinkedIn.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedIn.Controllers
{
    public class JobViewController : Controller
    {
        private readonly AppDb _db;

        public JobViewController(AppDb db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<JobView> onj = _db.jobViews.ToList();
            return View(onj);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Select = _db.jobCategories;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Add(JobView jobView)
        {
            ViewBag.Select = _db.jobCategories;
            _db.jobViews.Add(jobView);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        
    }
}
