using Al.Core.DTOs.Admin.Factory;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Factories
{
    [Authorize(Roles = "Admin")]
    public class FactoriesModel : PageModel
    {
        private readonly IAdminFactoryService _adminFactoryService;

        public FactoriesModel(IAdminFactoryService adminFactoryService)
        {
            _adminFactoryService = adminFactoryService;
        }

        public BoxFactoryInList Model { get; set; }

        public void OnGet(int pageId)
        {
            Model = _adminFactoryService.GetFactoriesInList(pageId);
        }

        public IActionResult OnGetDeleteFactory(int factoryId)
        {
            _adminFactoryService.DeleteFactory(factoryId);

            return RedirectToPage("Index");
        }
    }
}
