using Al.Core.DTOs.Admin.Country;
using Al.Core.IServices.Admin;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Factories
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminCountryService _adminCountryService;

        public IndexModel(IAdminCountryService adminCountryService)
        {
            _adminCountryService = adminCountryService;
        }

        public BoxCountryInList Model { get; set; }

        public void OnGet(int pageId = 1)
        {
            Model = _adminCountryService.GetCountriesInList(pageId);
        }

        public IActionResult OnGetDeleteCountry (int countryId)
        {
            _adminCountryService.DeleteCountry(countryId);

            Model = _adminCountryService.GetCountriesInList();

            return Page();
        }
    }
}