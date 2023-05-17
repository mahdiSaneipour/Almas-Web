using Al.Domain.Entities.Factors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Profile
{
    public interface IPurchaseService
    {
        public ICollection<Factor> GeyPurchaseHistoryByUserId(string userId);

        public Factor GetFactorByFactorId(int factorId);
    }
}
