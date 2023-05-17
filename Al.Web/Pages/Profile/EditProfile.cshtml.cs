using Al.Core.DTOs.Profile;
using Al.Core.IServices.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Profile
{
    [Authorize]
    public class EditProfileModel : PageModel
    {
        private readonly IProfileService _profileService;

        public EditProfileModel(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [BindProperty]
        public ShowUserInformation Info { get; set; }

        public void OnGet()
        {
            Info = _profileService.GetUserInformationForProfile();
        }

        public IActionResult OnPost()
        {
            _profileService.EditUserInformation(Info);

            return RedirectToPage("Index");
        }
    }
}
