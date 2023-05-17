using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Product
{
    public class ShowProductsInList
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public long ProductPrice { get; set; }

        public int Group { get; set; }

        public string GroupName { get; set; }

        public int SubGroup { get; set; }

        public string SubGroupName { get; set; }
    }
}
