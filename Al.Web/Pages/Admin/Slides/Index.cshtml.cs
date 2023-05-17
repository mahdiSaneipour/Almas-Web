using Al.Core.DTOs.Admin.Slide;
using Al.Core.IServices.Admin;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Al.Web.Pages.Admin.Slides
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminSlideService _adminSlideService;
        private readonly IAdminProductService _adminProductService;

        public IndexModel(IAdminSlideService adminSlideService, IAdminProductService adminProductService)
        {
            _adminSlideService = adminSlideService;
            _adminProductService = adminProductService;
        }

        public BoxSlidesInList Model { get; set; }

        public IActionResult OnGet(int pageId = 1, int group = 0)
        {
            Model = _adminSlideService.GetSlidesForShow(pageId, group);

            if (pageId != Model.PageId && pageId != 1)
            {
                string oldPageId = $"pageId={pageId}";
                string newPageId = $"pageId={Model.PageId}";
                string url = HttpContext.Request.Path + HttpContext.Request.QueryString.Value.Replace(oldPageId, newPageId);

                return Redirect(url);
            }

            ViewData["LGroups"] = _adminProductService.GetAllParentGroups();
            ViewData["Group"] = group;

            return Page();
        }

        public IActionResult OnGetDeleteSlide(int slideId)
        {
            _adminSlideService.DisableProductSlide(slideId);

            Model = _adminSlideService.GetSlidesForShow();

            ViewData["LGroups"] = _adminProductService.GetAllParentGroups();
            ViewData["Group"] = 0;

            return Page();
        }
    }
}
