using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Slide
{
    public class SingleSlideInList
    {
        public int SlideId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }
    }
}
