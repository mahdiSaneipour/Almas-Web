using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.IRepository.Factors.Factor
{
    public interface IFactorRepository
    {
        public IQueryable<Entities.Factors.Factor> GetAllFactorsByUserId(string userId);

        public Entities.Factors.Factor GetFactorByFactorId(int factorId);

        public Entities.Factors.Factor GetOpenFactorByUserId(string userId);

        public Entities.Factors.Factor GetLastCloseFactor();

        public IQueryable<Entities.Factors.Factor> GetAllFactors();

        public void SetDeliverByFactorId(int factorId);

        public Task<int> GetAllCountsSell();

        public long GetAllAmountSell();

        public int CountOfBasket(string userId);

        public int GetTotalOrders();

        public int GetTotalDeliveringOrders();

        public void AddFactor(Entities.Factors.Factor factor);

        public void UpdateFactor(Entities.Factors.Factor factor);

        public void RemoveFactor(Entities.Factors.Factor factor);

        public void SaveChanges();
    }
}
