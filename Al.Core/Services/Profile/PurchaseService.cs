using Al.Core.IServices.Profile;
using Al.Data.Context;
using Al.Domain.Entities.Factors;
using Al.Domain.IRepository.Factors.Factor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Profile
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IFactorRepository _factorRepository;

        public PurchaseService(IFactorRepository factorRepository)
        {
            _factorRepository = factorRepository;
        }

        public Factor GetFactorByFactorId(int factorId)
        {
            return _factorRepository.GetFactorByFactorId(factorId);
        }

        public ICollection<Factor> GeyPurchaseHistoryByUserId(string userId)
        {
            return _factorRepository.GetAllFactorsByUserId(userId).OrderByDescending(f => f.CreatDate).ToList();
        }
    }
}
