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
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryFactory factory;

        public CustomerService(IRepositoryFactory repositoryFactory)
        {
            factory = repositoryFactory;
        }

        public async Task AddOrUpdateAsync(Customer customer)
        {
            var customerRepo = factory.GetCustomerRepository();

            var dbCustomer = await customerRepo.FindAsync(customer.Id);

            if (dbCustomer == null)
            {
                customer.Id = default(int);
                await customerRepo.AddAsync(customer);
            }
            else
            {
                await customerRepo.UpdateAsync(dbCustomer, customer);
            }

            await factory.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            var customerRepo = factory.GetCustomerRepository();

            var dbCustomer = await customerRepo.FindAsync(customer.Id);

            if (dbCustomer == null)
                return;

            await customerRepo.DeleteAsync(customer);
            await factory.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customerRepo = factory.GetCustomerRepository();

            return await customerRepo.ToListAsync();
        }
    }
}
