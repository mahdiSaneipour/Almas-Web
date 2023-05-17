using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Factoe
{
    public class ShowFactorTableViewModel
    {
        public int FactorId { get; set; }

        public string FactorName { get; set; }

        public DateTime CreatDate { get; set; }

        public int Count { get; set; }

        public long Sum { get; set; }

        public bool IsDeliver { get; set; }
    }
}
