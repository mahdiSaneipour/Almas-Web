using Al.Core.DTOs.Admin.Color;
using Al.Core.DTOs.Admin.Country;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Color;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Admin
{
    public class AdminColorService : IAdminColorService
    {
        private readonly IColorRepository _colorRepository;

        public AdminColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public void AddColor(ProductColor color)
        {
            _colorRepository.AddColor(color);
            _colorRepository.SaveChanges();
        }

        public void DeleteColor(int colorId)
        {
            ProductColor color = _colorRepository.GetColorByColorId(colorId);

            if(color == null)
            {
                return;
            }

            _colorRepository.RemoveColor(color);
            _colorRepository.SaveChanges();
        }

        public void EditColor(ProductColor color)
        {
            _colorRepository.UpdateColor(color);
            _colorRepository.SaveChanges();
        }

        public ProductColor GetColorByColorId(int colorId)
        {
            return _colorRepository.GetColorByColorId(colorId);
        }

        public BoxColorsInList GetColorsInList(int pageId = 1)
        {
            BoxColorsInList result = new BoxColorsInList();


            IQueryable<ProductColor> countries = _colorRepository.GetAllColors();

            if (countries == null)
            {
                return result;
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            int totalPage = countries.Count() / take;

            result.Colors = countries.ToList().Skip(skip).Take(take).ToList();
            result.PageId = pageId;
            result.TotalPage = totalPage;

            return result;
        }
    }
}
