using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Factory
{
    public class BoxFactoryInList
    {
        public int PageId { get; set; } = 1;

        public int TotalPage { get; set; }

        public List<Domain.Entities.Product.ProductFactory> Factories { get; set; }
    }
}
