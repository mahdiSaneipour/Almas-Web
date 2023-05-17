using Al.Core.IServices.Admin;
using Al.Domain.IRepository.Factors.Factor;
using Al.Domain.IRepository.Products.Product;
using Al.Domain.IRepository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IFactorRepository _factorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public AdminService(IFactorRepository factorRepository, IUserRepository userRepository, 
            IProductRepository productRepository)
        {
            _factorRepository = factorRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public long GetAllAmountSell()
        {
            return _factorRepository.GetAllAmountSell();
        }

        public int GetAllCountsSell()
        {
            return _factorRepository.GetAllCountsSell().Result;
        }

        public int GetTotalDeliveringOrders()
        {
            return _factorRepository.GetTotalDeliveringOrders();
        }

        public int GetTotalOrders()
        {
            return _factorRepository.GetTotalOrders();
        }

        public int GetTotalProducts()
        {
            return _productRepository.GetTotalProducts();
        }

        public int GetTotalUsers()
        {
            return _userRepository.GetTotalUsers();
        }
    }
}
