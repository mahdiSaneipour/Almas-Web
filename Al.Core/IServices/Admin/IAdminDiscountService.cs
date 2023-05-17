using Al.Core.DTOs.Admin.Discount;
using Al.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Admin
{
    public interface IAdminDiscountService
    {
        public DiscountsListViewModel GetDiscountsInList(int pageId = 1);

        public SingleDiscountViewModel GetDiscountForEdit(int discountId);

        public void UpdateDiscount(SingleDiscountViewModel model);

        public void AddDiscount(SingleDiscountViewModel discount);

        public void DeleteDicount(int discountId);
    }
}
