using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.Entities.Admin
{
    public class SlideBanner
    {
        [Key]
        public int BannerId { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "آدرس بنر")]
        public string Link { get; set; }
    }
}
