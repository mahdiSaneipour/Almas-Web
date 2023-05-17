using Al.Core.DTOs.Admin.Factoe;
using Al.Core.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Orders
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminFactorService _adminFactorService;

        public IndexModel(IAdminFactorService adminFactorService)
        {
            _adminFactorService = adminFactorService;
        }

        [BindProperty]
        public Tuple<int, List<ShowFactorTableViewModel>> Model { get; set; }

        public IActionResult OnGet(int pageId = 1, Core.Enums.Admin.FactorsFilterBy filter = Core.Enums.Admin.FactorsFilterBy.All)
        {
            Model = Tuple.Create(_adminFactorService.GetFactorsForList(pageId, filter).Item1,
                _adminFactorService.GetFactorsForList(pageId, filter).Item3);

            if(pageId != _adminFactorService.GetFactorsForList(pageId, filter).Item2)
            {
                string oldPageId = $"pageId={pageId}";
                string newPageId = $"pageId={_adminFactorService.GetFactorsForList(pageId, filter).Item2}";
                string url = HttpContext.Request.Path + HttpContext.Request.QueryString.Value.Replace(oldPageId, newPageId);

                return Redirect(url);
            }

            ViewData["Filter"] = filter;
            ViewData["PageId"] = pageId;

            return Page();
        }
    }
}
