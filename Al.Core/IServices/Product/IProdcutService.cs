using Al.Core.DTOs.Product;
using Al.Core.DTOs.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Product
{
    public interface IProdcutService
    {
        public ProductShowViewModel GetProductByProductId(int productId);

        public SearchViewModel SearchProduct(SearchViewModel model);
    }
}
