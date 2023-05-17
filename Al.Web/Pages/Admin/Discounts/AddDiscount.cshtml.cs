using Al.Core.DTOs.Admin.Discount;
using Al.Core.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Discounts
{
    [Authorize(Roles = "Admin")]
    public class AddDiscountModel : PageModel
    {
        private readonly IAdminDiscountService _adminDiscountService;

        public AddDiscountModel(IAdminDiscountService adminDiscountService)
        {
            _adminDiscountService = adminDiscountService;
        }

        [BindProperty]
        public SingleDiscountViewModel Discount { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _adminDiscountService.AddDiscount(Discount);

            return RedirectToPage("Index");
        }
    }
}
