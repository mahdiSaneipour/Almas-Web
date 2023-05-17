using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Admin
{
    public interface IAdminService
    {
        public int GetAllCountsSell();

        public long GetAllAmountSell();

        public int GetTotalUsers();

        public int GetTotalOrders();

        public int GetTotalDeliveringOrders();

        public int GetTotalProducts();
    }
}