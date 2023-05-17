using Al.Core.DTOs.Admin.Product;
using Al.Core.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Al.Web.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class EditProductModel : PageModel
    {
        private readonly IAdminProductService _adminProductService;

        public EditProductModel(IAdminProductService adminProductService)
        {
            _adminProductService = adminProductService;
        }

        [BindProperty]
        public EditProduct Product { get; set; }

        public void OnGet(int productId)
        {
            Product = _adminProductService.GetProductEdit(productId);

            SelectList groups = _adminProductService.GetAllParentGroupsForShow();
            ViewData["LGroups"] = groups;

            ViewData["LSubGroups"] = _adminProductService.GetGroupsByParentIdForShow(Product.GroupId);

            ViewData["LCountries"] = _adminProductService.GetAllCountriesForShow();
            ViewData["LColors"] = _adminProductService.GetAllCountriesForShow();
            ViewData["LFactories"] = _adminProductService.GetAllFactoriesForShow();
            ViewData["LYears"] = _adminProductService.GetAllYearsForShow();

        }
    }
}
