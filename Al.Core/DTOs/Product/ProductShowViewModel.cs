using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Product
{
    public class ProductShowViewModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string GroupName { get; set; }

        public int GroupId { get; set; }

        public string ParentGroupName { get; set; }

        public int ParentGroupId { get; set; }

        public string ModelName { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        public string Country { get; set; }

        public string Factory { get; set; }

        public long Price { get; set; }

        public long OldPrice { get; set; }

        public string Description { get; set; }

        public int Count { get; set; } = 1;

        public string[] Images { get; set; }
    }
}
