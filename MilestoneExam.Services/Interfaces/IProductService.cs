using MilestoneExam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Services.Interfaces
{
    public interface IProductService
    {
        Task AddOrUpdateAsync(Product product);

        Task DeleteAsync(Product product);

        Task<IEnumerable<Product>> GetProducts();
    }
}
