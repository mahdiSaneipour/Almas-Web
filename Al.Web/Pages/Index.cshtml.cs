using Al.Core.IServices.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHomeService _homeService;

        public IndexModel(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public void OnGet()
        {
            ViewData["Banners"] = _homeService.GetSlideBanners();
            ViewData["Slides"] = _homeService.GetAllProductSlides();
            ViewData["Goldens"] = _homeService.GetGoldenDiscounts();
        }
    }
}