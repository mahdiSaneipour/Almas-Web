using Al.Core.DTOs.Admin.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Admin
{
    public interface IAdminBannerService
    {
        public BoxBannerInList GetBannersInList(int pageId = 1);

        public Domain.Entities.Admin.SlideBanner GetBanner(int bannerId);

        public void EditBanner(Domain.Entities.Admin.SlideBanner banner);

        public void AddBanner(Domain.Entities.Admin.SlideBanner banner);

        public void DeleteBanner(int bannerId);
    }
}