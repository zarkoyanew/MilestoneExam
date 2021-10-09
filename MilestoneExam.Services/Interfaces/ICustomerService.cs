using MilestoneExam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Services.Interfaces
{
    public interface ICustomerService
    {
        Task AddOrUpdateAsync(Customer product);

        Task DeleteAsync(Customer product);

        Task<IEnumerable<Customer>> GetCustomers();
    }
}
