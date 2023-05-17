using Al.Core.DTOs.Basket;
using Al.Core.IServices.Profile;
using Al.Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Profile
{
    [Authorize]
    public class BasketModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBasketService _basketService;

        public BasketModel(UserManager<ApplicationUser> userManager, IBasketService basketService)
        {
            _userManager = userManager;
            _basketService = basketService;
        }

        [BindProperty]
        public Domain.Entities.Factors.Factor Factor { get; set; }

        public async void OnGet()
        {
            Factor = _basketService.GetOpenFactorByUserId();
        }

        public async Task<IActionResult> OnPostAddToBasket(AddToBasketViewModel model)
        {
            model.User = await _userManager.GetUserAsync(HttpContext.User);
            _basketService.AddToBasket(model);

            return RedirectToPage("Basket");
        }

        public IActionResult OnGetRemoveProduct(int factorId, int productId)
        {
            _basketService.RemoveProductFromBasket(factorId, productId);

            return RedirectToPage("Basket");
        }

        public IActionResult OnGetPayFactor()
        {
            IActionResult result = _basketService.PayFactor().Result;

            if (result == null)
            {
                return RedirectToPage("Basket");
            }

            return result;
        }

        public async Task<IActionResult> OnGetVerify()
        {
            bool result = _basketService.VerifyPayment().Result;

            if (result)
            {
                _basketService.AddPriceToFactorDetails();
            }

            return await Task.FromResult(RedirectToPage("PurchaseHistory"));
        }
    }
}
