using Al.Core.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Banners
{
    [Authorize(Roles = "Admin")]
    public class AddBannerModel : PageModel
    {
        private readonly IAdminBannerService _adminBannerService;

        public AddBannerModel(IAdminBannerService adminBannerService)
        {
            _adminBannerService = adminBannerService;
        }

        [BindProperty]
        public Domain.Entities.Admin.SlideBanner Banner { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            _adminBannerService.AddBanner(Banner);

            return RedirectToPage("Index");
        }
    }
}
