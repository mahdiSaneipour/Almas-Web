using Al.Core.DTOs.Admin.Product;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Admin
{
    public interface IAdminProductService
    {
        public BoxProductsList GetProductsForList(int pageId, string search, int group, int subGroup);

        public List<string> SearchProduct(string term);

        public List<string> SearchProductNotSlide(string term);

        public SelectList GetAllParentGroups();

        public EditProduct GetProductEdit(int productId);

        public SelectList GetGroupsByParentId(int parentId);

        public SelectList GetAllParentGroupsForShow();

        public SelectList GetGroupsByParentIdForShow(int parentId);

        public SelectList GetAllCountriesForShow();

        public SelectList GetAllYearsForShow();

        public SelectList GetAllFactoriesForShow();

        public SelectList GetAllColorsForShow();

        public bool AddProduct(AddProduct product);

        public void DeleteProductByProductId(int productId);
    }
}