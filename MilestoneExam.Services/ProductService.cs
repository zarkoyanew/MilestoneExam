using MilestoneExam.Common.Exceptions;
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
    public class ProductService : IProductService
    {
        private readonly IRepositoryFactory factory;
        public ProductService(IRepositoryFactory repositoryFactory)
        {
            factory = repositoryFactory;
        }

        public async Task AddOrUpdateAsync(Product product)
        {
            var productRepo = factory.GetProductRepository();

            var dbProduct = await productRepo.FindAsync(product.Id);

            if (dbProduct == null)
            {
                product.Id = default(int);
                await productRepo.AddAsync(product);
            }
            else
            {
                await productRepo.UpdateAsync(dbProduct, product);
            }

            await factory.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            var productRepo = factory.GetProductRepository();

            var dbProduct = await productRepo.FindAsync(product.Id);

            if (dbProduct == null)
                throw new EntityNotFoundException($"{typeof(Product).Name} with key: {product.Id} not found.");

            await productRepo.DeleteAsync(dbProduct);
            await factory.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var productRepo = factory.GetProductRepository();

            return await productRepo.ToListAsync();
        }
    }
}
