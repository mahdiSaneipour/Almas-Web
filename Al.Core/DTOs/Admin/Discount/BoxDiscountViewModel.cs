using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Discount
{
    public class BoxDiscountViewModel
    {
        public int DiscountId { get; set; }

        public string DiscountName { get; set; }

        public int DiscountPercent { get; set; }

        public string ProductName { get; set; }

        public int ProductId { get; set; }

        public bool IsGolden { get; set; }
    }
}
