using LinkedIn.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedIn.ViewModel
{
    public class JobOfferVM
    {
        public JobOffer JobOffer { get; set; }

        public IEnumerable<SelectListItem> JobCategoryList {get; set;}
    }
}
