using MilestoneExam.Data.Models;
using MilestoneExam.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MilestoneExam.Data.Repositories
{
    public class RepositoryFactory : IRepositoryFactory, IDisposable
    {
        private IMainDataContext Context { get; set; }
        public RepositoryFactory(IDesignTimeDbContextFactory<MainDataContext> contextFactory)
        {
            Context = contextFactory.CreateDbContext(null);
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public ICustomerRepository GetCustomerRepository()
        {
            return new CustomerRepository(Context);
        }

        public IProductRepository GetProductRepository()
        {
            return new ProductRepository(Context);
        }

        public IGenericRepository<Purchase> GetPurchaseRepository()
        {
            return new GenericRepository<Purchase>(Context);
        }


        public void Dispose()
        {
            Context?.Dispose();
            Context = null;
        }
    }
}
