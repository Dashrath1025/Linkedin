using LinkedIn.Data;
using LinkedIn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedIn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDb _db;

        public HomeController(ILogger<HomeController> logger, AppDb db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<JobOffer> obj = _db.jobOffers;
            return View(obj);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Search(string companyName, string jobName, decimal salaryMin, decimal salaryMax)
        {
            DateTime currentTime = DateTime.Now;
            IEnumerable<JobOffer> jobOffers = _db.jobOffers;

            IEnumerable<JobOffer> filteredJobOffers = jobOffers;

            if (!string.IsNullOrEmpty(companyName))
            {
                filteredJobOffers = filteredJobOffers.Where(o => o.CompanyName.Contains(companyName, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(jobName))
            {
                filteredJobOffers = filteredJobOffers.Where(o => o.JobName.Contains(jobName, StringComparison.OrdinalIgnoreCase));
            }

            if (salaryMin > 0)
            {
                filteredJobOffers = filteredJobOffers.Where(o => o.Salary >= salaryMin);
            }

            if (salaryMax > 0)
            {
                filteredJobOffers = filteredJobOffers.Where(o => o.Salary <= salaryMax);
            }

            return View(filteredJobOffers);
        }


    }
}
