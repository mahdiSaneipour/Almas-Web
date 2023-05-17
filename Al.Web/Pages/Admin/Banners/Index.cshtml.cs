using Al.Core.DTOs.Admin.Banner;
using Al.Core.IServices.Admin;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Admin.Banners
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminBannerService _adminBannerService;

        public IndexModel(IAdminBannerService adminBannerService)
        {
            _adminBannerService = adminBannerService;
        }

        public BoxBannerInList Model { get; set; }

        public void OnGet(int pageId = 1)
        {
            Model = _adminBannerService.GetBannersInList(pageId);
        }

        public IActionResult OnGetDeleteBanner(int bannerId)
        {
            _adminBannerService.DeleteBanner(bannerId);

            Model = _adminBannerService.GetBannersInList();

            return Page();
        }
    }
}
