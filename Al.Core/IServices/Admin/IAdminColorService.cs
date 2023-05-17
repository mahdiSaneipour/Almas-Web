using Al.Core.DTOs.Admin.Color;
using Al.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Admin
{
    public interface IAdminColorService
    {
        public BoxColorsInList GetColorsInList(int pageId = 1);

        public ProductColor GetColorByColorId(int colorId);

        public void DeleteColor(int colorId);

        public void AddColor(ProductColor color);

        public void EditColor(ProductColor color);
    }
}
