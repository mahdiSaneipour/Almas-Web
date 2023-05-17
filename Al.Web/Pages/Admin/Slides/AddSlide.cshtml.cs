using Al.Core.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Slides
{
    [Authorize(Roles = "Admin")]
    public class AddSlideModel : PageModel
    {
        private readonly IAdminSlideService _adminSlideService;

        public AddSlideModel(IAdminSlideService adminSlideService)
        {
            _adminSlideService = adminSlideService;
        }

        [BindProperty]
        public string ProductName { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            bool result = _adminSlideService.AddSlideByName(ProductName);

            if(!result)
            {
                ModelState.AddModelError("ProductName", "محصولی با این نام وجود ندارد, لطفا گزینه های موجود را انتخاب کنید");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
