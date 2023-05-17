using Al.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.IRepository.Admins.SlideBanner
{
    public interface ISlideBannerRepository
    {
        public IQueryable<Entities.Admin.SlideBanner> GetAllBanners();

        public Entities.Admin.SlideBanner GetBannerByBannerId(int bannerId);

        public void AddBanner(Entities.Admin.SlideBanner banner);

        public void DeleteBanner(Entities.Admin.SlideBanner banner);

        public void UpdateBanner(Entities.Admin.SlideBanner banner);

        public void SaveChanges();
    }
}
