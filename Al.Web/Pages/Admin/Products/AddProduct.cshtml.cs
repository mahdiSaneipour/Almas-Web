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
    public class AddProductModel : PageModel
    {
        private readonly IAdminProductService _adminProductService;

        public AddProductModel(IAdminProductService adminProductService)
        {
            _adminProductService = adminProductService;
        }

        [BindProperty]
        public AddProduct Product { get; set; }

        public void OnGet()
        {
            SelectList groups = _adminProductService.GetAllParentGroupsForShow();
            ViewData["LGroups"] = groups;

            int parentId = Int32.Parse(groups.FirstOrDefault().Value);
            ViewData["LSubGroups"] = _adminProductService.GetGroupsByParentIdForShow(parentId);

            ViewData["LCountries"] = _adminProductService.GetAllCountriesForShow();
            ViewData["LColors"] = _adminProductService.GetAllColorsForShow();
            ViewData["LFactories"] = _adminProductService.GetAllFactoriesForShow();
            ViewData["LYears"] = _adminProductService.GetAllYearsForShow();

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                SelectList groups = _adminProductService.GetAllParentGroupsForShow();
                ViewData["LGroups"] = groups;

                int parentId = Int32.Parse(groups.FirstOrDefault().Value);
                ViewData["LSubGroups"] = _adminProductService.GetGroupsByParentIdForShow(parentId);

                ViewData["LCountries"] = _adminProductService.GetAllCountriesForShow();
                ViewData["LColors"] = _adminProductService.GetAllCountriesForShow();
                ViewData["LFactories"] = _adminProductService.GetAllFactoriesForShow();
                ViewData["LYears"] = _adminProductService.GetAllYearsForShow();

                return Page();
            }

            Console.WriteLine("Images : " + Product.Images);

            _adminProductService.AddProduct(Product);

            return RedirectToPage("Index");
        }
    }
}
