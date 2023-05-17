using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Admin.Colors
{
    [Authorize(Roles = "Admin")]
    public class AddColorModel : PageModel
    {
        private readonly IAdminColorService _adminColorService;

        public AddColorModel(IAdminColorService adminColorService)
        {
            _adminColorService = adminColorService;
        }

        [BindProperty]
        public ProductColor Color { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (String.IsNullOrEmpty(Color.ColorName))
            {
                return Page();
            }

            _adminColorService.AddColor(Color);

            return RedirectToPage("Index");
        }
    }
}
