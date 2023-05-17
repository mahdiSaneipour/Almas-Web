using Al.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Basket
{
    public class AddToBasketViewModel
    {
        public int ProductId { get; set; }

        public int Count { get; set; }

        public ApplicationUser User { get; set; }
    }
}
