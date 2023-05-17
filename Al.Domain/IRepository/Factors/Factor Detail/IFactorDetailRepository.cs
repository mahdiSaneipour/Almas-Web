using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.IRepository.Factors.Factor_Detail
{
    public interface IFactorDetailRepository
    {
        public IQueryable<Entities.Factors.FactorDetail> GetAllFactorDetailsByFactorId(int factorId);

        public Entities.Factors.FactorDetail GetFactorDetailByFactorDetailId(int factorDetailId);

        public Entities.Factors.FactorDetail GetFactorDetailByFactorIdAndProductId(int factorId, int productId);

        public void AddFactorDetail(Entities.Factors.FactorDetail factorDetail);

        public void UpdateFactorDetail(Entities.Factors.FactorDetail factorDetail);

        public void RemoveFactorDetail(Entities.Factors.FactorDetail factorDetail);

        public void SaveChanges();
    }
}
