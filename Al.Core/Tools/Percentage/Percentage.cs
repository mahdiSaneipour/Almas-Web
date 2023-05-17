using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Tools.Percentage
{
    public static class Percentage
    {
        public static long PercentagePrice(long price, int discount) {
            long result = price - ((price / 100) * discount);
            return result;
        }
    }
}
