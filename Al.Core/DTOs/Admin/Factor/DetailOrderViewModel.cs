using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Factor
{
    public class DetailOrderViewModel
    {
        public string ProductName { get; set; }

        public int Count { get; set; }

        public long Price { get; set; }

        public int DiscountPercent { get; set; }
    }
}
