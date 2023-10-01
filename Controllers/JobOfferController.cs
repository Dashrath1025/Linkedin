using LinkedIn.Data;
using LinkedIn.Models;
using LinkedIn.ViewModel;
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
    public class JobOfferController : Controller
    {
        private readonly AppDb _db;

        public JobOfferController(AppDb db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<JobOffer> objList = _db.jobOffers.Include(u => u.JobCategory);
            return View(objList);
        }

        [HttpGet]

       public IActionResult Upsert(int? id)
        {
            JobOfferVM jobOfferVM = new JobOfferVM()
            {
                JobOffer = new JobOffer(),
                JobCategoryList = _db.jobCategories.Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = e.CategoryName,
                    Value = e.Id.ToString()
                })
            };

            if(id== null)
            {
                // create
                return View(jobOfferVM);
            }
            else
            {
                jobOfferVM.JobOffer = _db.jobOffers.Find(id);
                if(jobOfferVM.JobOffer == null)
                {
                    return NotFound();
                }

                return View(jobOfferVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(JobOfferVM jobOffervm)
        {
            if (ModelState.IsValid)
            {
                if (jobOffervm.JobOffer.Id == 0)
                {
                    _db.jobOffers.Add(jobOffervm.JobOffer);
                }
                else
                {
                    var objfromdb = _db.jobOffers.AsNoTracking().FirstOrDefault(i => i.Id == jobOffervm.JobOffer.Id);

                    if (objfromdb == null)
                    {
                        return NotFound();
                    }

                    _db.Update(jobOffervm.JobOffer);

                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            jobOffervm.JobCategoryList = _db.jobCategories.Select(o => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = o.CategoryName,
                Value = o.Id.ToString()
            });
            return View(jobOffervm);
        }

        public IActionResult Delete(int? id)
        {
            if(id ==null && id == 0)
            {
                return NotFound();
            }

            var obj = _db.jobOffers.Where(e => e.Id == id).FirstOrDefault();

            _db.jobOffers.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
