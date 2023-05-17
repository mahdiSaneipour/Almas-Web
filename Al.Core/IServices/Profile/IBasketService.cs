using Al.Core.DTOs.Basket;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Profile
{
    public interface IBasketService
    {
        public void AddToBasket(AddToBasketViewModel model);

        public Domain.Entities.Factors.Factor GetOpenFactorByUserId();

        public void RemoveProductFromBasket(int factorId, int productId);

        public void AddPriceToFactorDetails();

        public long SetFactorAmount(int factorId);

        public Task<IActionResult> PayFactor();

        public Task<bool> VerifyPayment();

        public int CountOfBasket();

        public long GetActualPrice(int productId);
    }
}
