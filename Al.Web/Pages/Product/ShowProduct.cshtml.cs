using Al.Core.DTOs.Product;
using Al.Core.IServices.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Product
{
    public class ShowProductModel : PageModel
    {
        private readonly IProdcutService _prodcutService;

        public ShowProductModel(IProdcutService prodcutService)
        {
            _prodcutService = prodcutService;
        }

        public ProductShowViewModel Product { get; set; }

        public IActionResult OnGet(int productId)
        {
            Product = _prodcutService.GetProductByProductId(productId);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
