using Al.Core.DTOs.Search;
using Al.Core.IServices.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Product
{
    public class SearchModel : PageModel
    {
        private readonly IProdcutService _prodcutService;

        public SearchModel(IProdcutService prodcutService)
        {
            _prodcutService = prodcutService;
        }

        [BindProperty]
        public SearchViewModel Search { get; set; }

        public void OnGet(List<int> groups, SearchViewModel Search)
        {
            Search.Groups = groups;

            this.Search = new SearchViewModel();
            this.Search = _prodcutService.SearchProduct(Search);

            this.Search.MinimumPrice = Search.MinimumPrice;
            this.Search.MaximumPrice = Search.MaximumPrice;

            ViewData["Selected"] = groups;
        }
    }
}
