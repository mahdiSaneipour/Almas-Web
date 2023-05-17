using Al.Core.DTOs.Home;
using Al.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Home
{
    public interface IHomeService
    {
        public ICollection<SlideBannerViewModel> GetSlideBanners();

        public ICollection<ProductSlidesViewModel> GetAllProductSlides();

        public ICollection<ProductBoxViewModel> GetGoldenDiscounts();
    }
}
