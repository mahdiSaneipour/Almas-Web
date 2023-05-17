using Al.Core.DTOs.Admin.Slide;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Admin
{
    public interface IAdminSlideService
    {
        public BoxSlidesInList GetSlidesForShow(int pageId = 1, int groupId = 0);

        public void DisableProductSlide(int productId);

        public bool AddSlideByName(string productName);
    }
}
