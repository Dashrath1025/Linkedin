using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedIn.Models
{
    public class JobCategory
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50,ErrorMessage ="Maximum length is 50 character")]
        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
    }
}
