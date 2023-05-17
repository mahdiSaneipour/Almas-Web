using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Home
{
    public class ProductBoxViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public long OldPrice { get; set; }

        public long NewPrice { get; set; }
    }
}
