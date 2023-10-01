using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedIn.Models
{
    public class JobSeeker
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
      //  [MaxLength(10,ErrorMessage ="Only 10 digit are allowed")]
        public int Mobile { get; set; }

        public string Resume { get; set; }

        public bool Experience { get; set; }
    }
}
