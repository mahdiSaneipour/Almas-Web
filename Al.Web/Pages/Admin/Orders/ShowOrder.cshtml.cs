using Al.Core.DTOs.Admin.Factor;
using Al.Core.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Admin.Orders
{
    [Authorize(Roles = "Admin")]
    public class ShowOrderModel : PageModel
    {
        private readonly IAdminFactorService _factorService;

        public ShowOrderModel(IAdminFactorService factorService)
        {
            _factorService = factorService;
        }

        public ShowUserAndOrderViewModel Model { get; set; }

        public void OnGet(int orderId)
        {
            Model = _factorService.GetShowOrder(orderId);
        }

        public IActionResult OnGetSetDeliver(int orderId)
        {
            _factorService.SetDeliverByFactorId(orderId);
            return RedirectToPage("ShowOrder", new { orderId = orderId });
        }
    }
}
