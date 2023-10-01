using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedIn.Models
{
    public class JobOffer
    {
        public int Id { get; set; }

        [Required]
        public string JobName { get; set; }

        [Required]
        public string CompanyName { get; set; }
       
        [Required]
        [Display(Name ="No Of Openings")]
        public int NoOfOpning { get; set; }

        public string JobType { get; set; }

        public Decimal Salary { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
        public bool isActive { get; set; }

        public int Contact { get; set; }

        public int JId { get; set; }


        [ForeignKey("JId")]
        public virtual JobCategory JobCategory { get; set; }

    }
}
