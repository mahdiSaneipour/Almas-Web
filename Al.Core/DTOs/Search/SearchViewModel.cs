using Al.Core.DTOs.Home;
using Al.Core.Enums.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Search
{
    public class SearchViewModel
    {
        public long MinimumPrice { get; set; } = 0;

        public long MaximumPrice { get; set; } = 20000000;

        public OrderByEnum OrderBy { get; set; } = OrderByEnum.Newest;

        public List<int> Groups { get; set; }

        public List<Domain.Entities.Product.ProductGroup> AllGroups { get; set; }

        public List<ProductBoxViewModel> Products { get; set; }

        public string Search { get; set; }

        public int PageId { get; set; } = 1;

        public int PageCount { get; set; } = 1;
    }
}
