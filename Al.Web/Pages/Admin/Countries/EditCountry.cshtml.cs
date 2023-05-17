using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Countries
{
    [Authorize(Roles = "Admin")]
    public class EditCountryModel : PageModel
    {

        private readonly IAdminCountryService _adminCountryService;

        public EditCountryModel(IAdminCountryService adminCountryService)
        {
            _adminCountryService = adminCountryService;
        }

        [BindProperty]
        public ProductCountry Country { get; set; }

        public IActionResult OnGet(int countryId)
        {
            Country = _adminCountryService.GetCountry(countryId);

            if (Country == null)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            _adminCountryService.UpdateCountry(Country);

            return RedirectToPage("Index");
        }
    }
}
