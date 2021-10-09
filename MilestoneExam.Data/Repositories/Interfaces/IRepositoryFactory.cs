using MilestoneExam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Data.Repositories.Interfaces
{
    public interface IRepositoryFactory
    {
        Task SaveChangesAsync();

        IProductRepository GetProductRepository();

        ICustomerRepository GetCustomerRepository();

        IGenericRepository<Purchase> GetPurchaseRepository();

    }
}
