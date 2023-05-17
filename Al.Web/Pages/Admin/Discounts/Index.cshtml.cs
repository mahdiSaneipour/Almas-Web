using Al.Core.DTOs.Admin.Discount;
using Al.Core.IServices.Admin;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Discounts
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminDiscountService _adminDiscountService;

        public IndexModel(IAdminDiscountService adminDiscountService)
        {
            _adminDiscountService = adminDiscountService;
        }

        public DiscountsListViewModel Model { get; set; }

        public void OnGet(int pageId)
        {
            Model = _adminDiscountService.GetDiscountsInList(pageId);
        }

        public IActionResult OnGetDeleteDiscount(int discountId)
        {
            _adminDiscountService.DeleteDicount(discountId);

            Model = _adminDiscountService.GetDiscountsInList();

            return Page();
        }
    }
}
