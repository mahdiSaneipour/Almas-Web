using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Discount
{
    public class SingleDiscountViewModel
    {
        public int DiscountId { get; set; }

        public string ProductName { get; set; }

        public string DiscountName { get; set; }

        public int Percent { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public bool IsGolden { get; set; }
    }
}
