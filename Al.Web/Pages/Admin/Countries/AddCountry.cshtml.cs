using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Countries
{
    [Authorize(Roles = "Admin")]

    public class AddCountryModel : PageModel
    {
        private readonly IAdminCountryService _adminCountryService;

        public AddCountryModel(IAdminCountryService adminCountryService)
        {
            _adminCountryService = adminCountryService;
        }

        [BindProperty]
        public ProductCountry Country { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            _adminCountryService.AddCountry(Country);

            return RedirectToPage("Index");
        }
    }
}
