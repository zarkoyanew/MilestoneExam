using MilestoneExam.Data.Models;
using MilestoneExam.Data.Repositories.Interfaces;
using MilestoneExam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IRepositoryFactory factory;
        public PurchaseService(IRepositoryFactory repositoryFactory)
        {
            factory = repositoryFactory;
        }

        public async Task AddAsync(Purchase purchase)
        {
            var purchaseRepo = factory.GetPurchaseRepository();

            await purchaseRepo.AddAsync(purchase);

            await factory.SaveChangesAsync();
        }

        public async Task DeleteAsync(Purchase purchase)
        {
            var purchaseRepo = factory.GetPurchaseRepository();

            var dbPurchase = await purchaseRepo.FirstOrDefaultAsync(p => p.CustomerId == purchase.CustomerId && p.ProductId == purchase.ProductId);

            if (dbPurchase == null)
                return;

            await purchaseRepo.DeleteAsync(purchase);
            await factory.SaveChangesAsync();
        }

        public async Task<Customer> GetPurchasesByCustomerName(string customerName)
        {
            var customerRepo = factory.GetCustomerRepository();

            return await customerRepo.FirstOrDefaultAsync(c => c.Name.Contains(customerName));
        }

        public async Task<Product> GetPurchasesByProductName(string productName)
        {
            var productRepo = factory.GetProductRepository();

            return await productRepo.FirstOrDefaultAsync(p => p.Name.Contains(productName));
        }
    }
}
