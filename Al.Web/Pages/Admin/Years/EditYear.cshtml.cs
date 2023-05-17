using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Years
{
    [Authorize(Roles = "Admin")]
    public class EditYearModel : PageModel
    {
        private readonly IAdminYearService _adminYearService;

        public EditYearModel(IAdminYearService adminYearService)
        {
            _adminYearService = adminYearService;
        }

        [BindProperty]
        public ProductYear Year { get; set; }

        public void OnGet(int yearId)
        {
            Year = _adminYearService.GetYearByYearId(yearId);
        }

        public IActionResult OnPost()
        {
            if (Year.ProductionYear == null)
            {
                return Page();
            }

            _adminYearService.UpdateYear(Year);

            return RedirectToPage("Index");
        }
    }
}
