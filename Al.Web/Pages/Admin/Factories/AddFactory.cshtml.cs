using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Factories
{
    [Authorize(Roles = "Admin")]
    public class AddFactoryModel : PageModel
    {
        private readonly IAdminFactoryService _adminFactoryService;

        public AddFactoryModel(IAdminFactoryService adminFactoryService)
        {
            _adminFactoryService = adminFactoryService;
        }

        [BindProperty]
        public ProductFactory Factory { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (String.IsNullOrEmpty(Factory.FactoryName))
            {
                return Page();
            }

            _adminFactoryService.AddFactory(Factory);

            return RedirectToPage("Index");
        }
    }
}
