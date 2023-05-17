using Al.Data.Context;
using Al.Domain.IRepository.Admins.SlideBanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Repository.Admins.SlideBanner
{
    public class SlideBannerRepository : ISlideBannerRepository
    {
        private readonly AlContext _context;

        public SlideBannerRepository(AlContext context)
        {
            _context = context;
        }

        public void AddBanner(Domain.Entities.Admin.SlideBanner banner)
        {
            _context.SlideBanners.Add(banner);
        }

        public void DeleteBanner(Domain.Entities.Admin.SlideBanner banner)
        {
            _context.SlideBanners.Remove(banner);
        }

        public IQueryable<Domain.Entities.Admin.SlideBanner> GetAllBanners()
        {
            return _context.SlideBanners;
        }

        public Domain.Entities.Admin.SlideBanner GetBannerByBannerId(int bannerId)
        {
            return _context.SlideBanners.FirstOrDefault(s => s.BannerId == bannerId);
        }

        public void UpdateBanner(Domain.Entities.Admin.SlideBanner banner)
        {
            _context.SlideBanners.Update(banner);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}