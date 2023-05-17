using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Product
{
    public class BoxProductsList
    {
        public int PageId { get; set; }

        public int TotalPage { get; set; }

        public List<ShowProductsInList> Products { get; set; }
    }
}
