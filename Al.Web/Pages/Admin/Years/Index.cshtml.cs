using Al.Core.DTOs.Admin.Year;
using Al.Core.IServices.Admin;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Years
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminYearService _adminYearService;

        public IndexModel(IAdminYearService adminYearService)
        {
            _adminYearService = adminYearService;
        }

        public BoxYearsInList Model { get; set; }

        public void OnGet(int pageId)
        {
            Model = _adminYearService.GetYearsInList(pageId);
        }

        public IActionResult OnGetDeleteYear(int yearId)
        {
            _adminYearService.DeleteYear(yearId);

            Model = _adminYearService.GetYearsInList();

            return Page();
        }
    }
}