using Al.Core.DTOs.Profile;
using Al.Core.IServices.Profile;
using Al.Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Profile
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IProfileService _profileService;

        public IndexModel(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public ShowUserInformation Info { get; set; }

        public void OnGet()
        {
            Info = _profileService.GetUserInformationForProfile();
        }
    }
}
