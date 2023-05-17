using Al.Core.IServices.Profile;
using Al.Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Profile
{
    [Authorize]
    public class ShowFactorModel : PageModel
    {
        private readonly IPurchaseService _purchaseService;

        public ShowFactorModel(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public Domain.Entities.Factors.Factor Factor { get; set; }

        public void OnGet(int factorId)
        {
            Factor = _purchaseService.GetFactorByFactorId(factorId);
        }
    }
}
