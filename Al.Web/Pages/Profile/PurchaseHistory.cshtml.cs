using Al.Core.IServices.Profile;
using Al.Domain.Entities.Factors;
using Al.Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Al.Web.Pages.Profile
{
    [Authorize]
    public class PurchaseHistoryModel : PageModel
    {
        private readonly IPurchaseService _purchaseService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PurchaseHistoryModel(IPurchaseService purchaseService,
            UserManager<ApplicationUser> userManager)
        {
            _purchaseService = purchaseService;
            _userManager = userManager;
        }

        public List<Factor> Factors { get; set; }

        public void OnGet()
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Factors = _purchaseService.GeyPurchaseHistoryByUserId(userId).ToList();
        }
    }
}
