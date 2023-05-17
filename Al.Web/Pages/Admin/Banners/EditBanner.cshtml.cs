using Al.Core.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Banners
{
    [Authorize(Roles = "Admin")]
    public class EditBannerModel : PageModel
    {
        private readonly IAdminBannerService _adminBannerService;

        public EditBannerModel(IAdminBannerService adminBannerService)
        {
            _adminBannerService = adminBannerService;
        }

        [BindProperty]
        public Domain.Entities.Admin.SlideBanner Banner { get; set; }

        public void OnGet(int bannerId)
        {
            Banner = _adminBannerService.GetBanner(bannerId);
        }

        public IActionResult OnPost()
        {
            _adminBannerService.EditBanner(Banner);

            return RedirectToPage("Index");
        }
    }
}
