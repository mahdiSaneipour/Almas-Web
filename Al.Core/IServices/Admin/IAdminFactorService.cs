using Al.Core.DTOs.Admin.Factoe;
using Al.Core.DTOs.Admin.Factor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Admin
{
    public interface IAdminFactorService
    {
        public Tuple<int, int, List<ShowFactorTableViewModel>> GetFactorsForList(int pageId = 1, Enums.Admin.FactorsFilterBy filter = Enums.Admin.FactorsFilterBy.All);

        public ShowUserAndOrderViewModel GetShowOrder(int orderId);

        public void SetDeliverByFactorId(int factorId);
    }
}
