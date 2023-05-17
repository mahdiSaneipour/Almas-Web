using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Home
{
    public class ProductSlidesViewModel
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public ICollection<ProductBoxViewModel> Slides { get; set; }
    }
}
