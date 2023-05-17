using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Year
{
    public class BoxYearsInList
    {
        public int PageId { get; set; } = 1;

        public int TotalPage { get; set; }

        public List<Domain.Entities.Product.ProductYear> Years { get; set; }
    }
}
