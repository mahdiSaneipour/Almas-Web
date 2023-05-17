using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Admin.Factories
{
    [Authorize(Roles = "Admin")]
    public class EditFactoryModel : PageModel
    {
        private readonly IAdminFactoryService _adminFactoryService;

        public EditFactoryModel(IAdminFactoryService adminFactoryService)
        {
            _adminFactoryService = adminFactoryService;
        }

        [BindProperty]
        public ProductFactory Factory { get; set; }

        public void OnGet(int factoryId)
        {
            Factory = _adminFactoryService.GetFactoryByFactoryId(factoryId);
        }

        public IActionResult OnPost()
        {
            if (String.IsNullOrEmpty(Factory.FactoryName))
            {
                return Page();
            }

            _adminFactoryService.UpdateFactory(Factory);

            return RedirectToPage("Index");
        }
    }
}
