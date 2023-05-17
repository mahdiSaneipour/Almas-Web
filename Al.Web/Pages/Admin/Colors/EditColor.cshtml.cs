using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Colors
{
    [Authorize(Roles = "Admin")]
    public class EditColorModel : PageModel
    {
        private readonly IAdminColorService _adminColorService;

        public EditColorModel(IAdminColorService adminColorService)
        {
            _adminColorService = adminColorService;
        }

        [BindProperty]
        public ProductColor Color { get; set; }

        public void OnGet(int colorId)
        {
            Color = _adminColorService.GetColorByColorId(colorId);
        }

        public IActionResult OnPost()
        {
            if (String.IsNullOrEmpty(Color.ColorName))
            {
                return Page();
            }

            _adminColorService.EditColor(Color);

            return RedirectToPage("Index");
        }
    }
}