using Al.Data.Context;
using Al.Domain.IRepository.Factors.Factor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Al.Data.Repository.Factors.Factor
{
    public class FactorRepository : IFactorRepository
    {
        private readonly AlContext _context;

        public FactorRepository(AlContext context)
        {
            _context = context;
        }

        public IQueryable<Domain.Entities.Factors.Factor> GetAllFactorsByUserId(string userId)
        {
            return _context.Factors.Where(f => f.UserId == userId && f.IsPay == true);
        }

        public int GetTotalOrders()
        {
            return _context.Factors.Where(f => f.IsPay).Count();
        }

        public void SetDeliverByFactorId(int factorId)
        {
            _context.Factors.FirstOrDefault(f => f.FactorId == factorId).IsDeliver = true;
        }

        public void AddFactor(Domain.Entities.Factors.Factor factor)
        {
            _context.Factors.Add(factor);
        }

        public Domain.Entities.Factors.Factor GetFactorByFactorId(int factorId)
        {
            return _context.Factors.Include(f => f.User).Include(f => f.FactorDetails).ThenInclude(fd => fd.Product).ThenInclude(p => p.Discount).FirstOrDefault(f => f.FactorId == factorId);
        }

        public void RemoveFactor(Domain.Entities.Factors.Factor factor)
        {
            _context.Factors.Remove(factor);
        }

        public void UpdateFactor(Domain.Entities.Factors.Factor factor)
        {
            _context.Factors.Update(factor);
        }

        public Domain.Entities.Factors.Factor GetOpenFactorByUserId(string userId)
        {
            return _context.Factors.Include(f => f.FactorDetails).Where(f => f.UserId == userId && f.IsPay == false).FirstOrDefault();
        }

        public Domain.Entities.Factors.Factor GetLastCloseFactor()
        {
            return _context.Factors.Include(f => f.FactorDetails)
                .Where(f => f.IsPay == true).OrderByDescending(f => f.CreatDate).Last();
        }


        public int CountOfBasket(string userId)
        {
            int count = 0;

            if(_context.Factors.FirstOrDefault(f => f.UserId == userId && f.IsPay == false) != null)
            {
                count = _context.Factors.Include(f => f.FactorDetails).FirstOrDefault(f => f.UserId == userId && f.IsPay == false).FactorDetails.Sum(fd => fd.Count);
            }

            return count;
        }

        public async Task<int> GetAllCountsSell()
        {
            return _context.Factors.Where(f => f.IsPay).Sum(f => f.Count);
        }

        public long GetAllAmountSell()
        {
            return _context.Factors.Where(f => f.IsPay).Sum(f => f.Sum);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public int GetTotalDeliveringOrders()
        {
            return _context.Factors.Where(f => f.IsPay && !f.IsDeliver).Count();
        }

        public IQueryable<Domain.Entities.Factors.Factor> GetAllFactors()
        {
            return _context.Factors.Include(f => f.User);
        }
    }
}