using Al.Core.IServices.Admin;
using Al.Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Al.Web.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminService _adminService;

        public IndexModel(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async void OnGet()
        {
            ViewData["SellCount"] = _adminService.GetAllCountsSell();
            ViewData["SellAmount"] = _adminService.GetAllAmountSell();
            ViewData["TotalUsers"] = _adminService.GetTotalUsers();
            ViewData["TotalOrders"] = _adminService.GetTotalOrders();
            ViewData["DeliveringOrders"] = _adminService.GetTotalDeliveringOrders();
            ViewData["TotalProducts"] = _adminService.GetTotalProducts();
        }
    }
}
