using Al.Core.DTOs.Admin.Banner;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Admin;
using Al.Domain.IRepository.Admins.SlideBanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Admin
{
    public class AdminBannerService : IAdminBannerService
    {
        private readonly ISlideBannerRepository _slideBannerRepository;

        public AdminBannerService(ISlideBannerRepository slideBannerRepository)
        {
            _slideBannerRepository = slideBannerRepository;
        }

        public void AddBanner(SlideBanner banner)
        {
            _slideBannerRepository.AddBanner(banner);
            _slideBannerRepository.SaveChanges();
        }

        public void DeleteBanner(int bannerId)
        {
            Domain.Entities.Admin.SlideBanner banner = _slideBannerRepository.GetBannerByBannerId(bannerId);

            if(banner == null)
            {
                return;
            }

            _slideBannerRepository.DeleteBanner(banner);
            _slideBannerRepository.SaveChanges();
        }

        public void EditBanner(SlideBanner banner)
        {
            _slideBannerRepository.UpdateBanner(banner);
            _slideBannerRepository.SaveChanges();
        }

        public SlideBanner GetBanner(int bannerId)
        {
            return _slideBannerRepository.GetBannerByBannerId(bannerId);
        }

        public BoxBannerInList GetBannersInList(int pageId = 1)
        {
            BoxBannerInList result = new BoxBannerInList();
            IQueryable<SlideBanner> banners = _slideBannerRepository.GetAllBanners();

            if (banners == null)
            {
                return result;
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            int totalPage = banners.Count() / take;

            result.Banners = banners.ToList().Skip(skip).Take(take).ToList();
            result.PageId = pageId;
            result.TotalPage = totalPage;

            return result;
        }
    }
}
