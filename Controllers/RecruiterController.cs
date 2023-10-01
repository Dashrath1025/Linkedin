using LinkedIn.Data;
using LinkedIn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedIn.Controllers
{
    [Authorize(Roles = "Employee")]

    public class RecruiterController : Controller
    {

        public AppDb _db;

        public RecruiterController(AppDb db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           IEnumerable<JobCategory> objLIst = _db.jobCategories;
          // IEnumerable<JobCategory> objData = _db.jobCategories;
            return View(objLIst);
        }


        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            JobCategory country = new JobCategory();

            if (id == null)
            {
                return View(country);
            }
            else
            {
                country = _db.jobCategories.Find(id);
                if (country == null)
                {
                    return NotFound();
                }
                return View(country);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(JobCategory job)
        {
            if (ModelState.IsValid)
            {
                if (job.Id == 0)
                {
                    //create
                    _db.jobCategories.Add(job);
                }
                else
                {
                    var objfromdb = _db.jobCategories.AsNoTracking().FirstOrDefault(e => e.Id == job.Id);

                    if (objfromdb == null)
                    {
                        return NotFound();
                    }
                    _db.jobCategories.Update(job);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.jobCategories.Where(i => i.Id == id).FirstOrDefault();

            _db.jobCategories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
