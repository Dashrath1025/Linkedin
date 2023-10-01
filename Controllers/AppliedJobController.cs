using LinkedIn.Data;
using LinkedIn.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedIn.Controllers
{
    public class AppliedJobController : Controller
    {

        private readonly AppDb _db;

        public AppliedJobController(AppDb db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<JobSeeker> objData = _db.jobSeekers;
            return View(objData);
        }
    }
}
