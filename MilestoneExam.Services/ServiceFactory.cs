using MilestoneExam.Data;
using MilestoneExam.Data.Repositories.Interfaces;
using MilestoneExam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Services
{
    public class ServiceFactory : IServiceFactory
    {
        IRepositoryFactory factory;

        public ServiceFactory(IRepositoryFactory repositoryFactory)
        {
            factory = repositoryFactory;
        }
        public ICustomerService GetCustomerService()
        {
            return new CustomerService(factory);
        }

        public IProductService GetProductService()
        {
            return new ProductService(factory);
        }

        public IPurchaseService GetPurchaseService()
        {
            return new PurchaseService(factory);
        }
    }
}
