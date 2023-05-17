using Al.Core.DTOs.Admin.Discount;
using Al.Core.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Admin.Discounts
{
    [Authorize(Roles = "Admin")]
    public class EditDiscountModel : PageModel
    {
        private readonly IAdminDiscountService _adminDiscountService;

        public EditDiscountModel(IAdminDiscountService adminDiscountService)
        {
            _adminDiscountService = adminDiscountService;
        }

        [BindProperty]
        public SingleDiscountViewModel Discount { get; set; }

        public void OnGet(int discountId)
        {
            Discount = _adminDiscountService.GetDiscountForEdit(discountId);
        }

        public IActionResult OnPost()
        {
            _adminDiscountService.UpdateDiscount(Discount);

            return RedirectToPage("Index");
        }
    }
}
