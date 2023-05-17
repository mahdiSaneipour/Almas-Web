using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Group
{
    public class BoxGroupInList
    {
        public int PageId { get; set; }

        public int TotalPage { get; set; }

        public List<Domain.Entities.Product.ProductGroup> Groups { get; set; }
    }
}
