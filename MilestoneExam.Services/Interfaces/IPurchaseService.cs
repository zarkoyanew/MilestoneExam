using MilestoneExam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task AddAsync(Purchase purchase);

        Task DeleteAsync(Purchase purchase);

        Task<Product> GetPurchasesByProductName(string productName);

        Task<Customer> GetPurchasesByCustomerName(string customerName);
    }
}
