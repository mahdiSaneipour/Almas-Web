using Al.Core.DTOs.Admin.Product;
using Al.Core.IServices.Admin;
using Al.Domain.IRepository.Products.Group;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Al.Web.Pages.Admin.Product
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminProductService _adminProductService;
        private readonly IGroupRepository _groupRepository;

        public IndexModel(IAdminProductService adminProductService, IGroupRepository groupRepository)
        {
            _adminProductService = adminProductService;
            _groupRepository = groupRepository;
        }

        public BoxProductsList Product { get; set; }

        public IActionResult OnGet(string? search, int group = 0, int subGroup = 0, int pageId = 1)
        {
            Product = _adminProductService.GetProductsForList(pageId, search, group, subGroup);

            if (pageId != Product.PageId && pageId != 1)
            {
                string oldPageId = $"pageId={pageId}";
                string newPageId = $"pageId={Product.PageId}";
                string url = HttpContext.Request.Path + HttpContext.Request.QueryString.Value.Replace(oldPageId, newPageId);

                return Redirect(url);
            }

            ViewData["Group"] = group;
            ViewData["SubGroup"] = subGroup;
            ViewData["PageId"] = pageId;
            ViewData["Search"] = search;

            SelectList groups = _adminProductService.GetAllParentGroups();
            ViewData["LGroups"] = groups;

            SelectList subGroups = _adminProductService.GetGroupsByParentId(group);
            ViewData["LSubGroups"] = subGroups;

            return Page();
        }

        public IActionResult OnGetDeleteProduct(int productId) {
            _adminProductService.DeleteProductByProductId(productId);

            Product = _adminProductService.GetProductsForList(1,"",0,0);

            SelectList groups = _adminProductService.GetAllParentGroups();
            ViewData["LGroups"] = groups;

            int parentId = Int32.Parse(groups.Skip(1).FirstOrDefault().Value);
            SelectList subGroups = _adminProductService.GetGroupsByParentId(parentId);
            ViewData["LSubGroups"] = subGroups;

            return RedirectToPage("Index");
        }
    }
}
