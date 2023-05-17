using Al.Data.Context;
using Al.Domain.Entities.Factors;
using Al.Domain.IRepository.Factors.Factor_Detail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Repository.Factors.Factor_Detail
{
    public class FactorDetailRepository : IFactorDetailRepository
    {
        private readonly AlContext _context;

        public FactorDetailRepository(AlContext context)
        {
            _context = context;
        }

        public void AddFactorDetail(FactorDetail factorDetail)
        {
            _context.FactorDetails.Add(factorDetail);
        }

        public IQueryable<FactorDetail> GetAllFactorDetailsByFactorId(int factorId)
        {
            return _context.FactorDetails;
        }

        public FactorDetail GetFactorDetailByFactorDetailId(int factorDetailId)
        {
            return _context.FactorDetails.FirstOrDefault(f => f.FactorId == factorDetailId);
        }

        public void RemoveFactorDetail(FactorDetail factorDetail)
        {
            _context.FactorDetails.Remove(factorDetail);
        }

        public void UpdateFactorDetail(FactorDetail factorDetail)
        {
            _context.FactorDetails.Update(factorDetail);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public FactorDetail GetFactorDetailByFactorIdAndProductId(int factorId, int productId)
        {
            return _context.FactorDetails.FirstOrDefault(fd => fd.FactorId == factorId && fd.ProductId == productId);
        }
    }
}
