using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Factor
{
    public class ShowUserAndOrderViewModel
    {
        public int OrderId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }

        public string Address { get; set; }

        public bool IsDeliver { get; set; }

        public DateTime CreatDate { get; set; }

        public List<DetailOrderViewModel> OrderDetails { get; set; }
    }
}
