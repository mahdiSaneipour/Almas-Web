using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Banner
{
    public class BoxBannerInList
    {
        public int PageId { get; set; } = 1;

        public int TotalPage { get; set; }

        public List<Domain.Entities.Admin.SlideBanner> Banners { get; set; }
    }
}
