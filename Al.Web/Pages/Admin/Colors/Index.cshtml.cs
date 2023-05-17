using Al.Core.DTOs.Admin.Color;
using Al.Core.IServices.Admin;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Admin.Colors
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminColorService _adminColorService;

        public IndexModel(IAdminColorService adminColorService)
        {
            _adminColorService = adminColorService;
        }

        public BoxColorsInList Model { get; set; }

        public void OnGet(int pageId = 1)
        {
            Model = _adminColorService.GetColorsInList(pageId);
        }

        public IActionResult OnGetDeleteColor(int colorId)
        {
            _adminColorService.DeleteColor(colorId);

            Model = _adminColorService.GetColorsInList();

            return Page();
        }
    }
}