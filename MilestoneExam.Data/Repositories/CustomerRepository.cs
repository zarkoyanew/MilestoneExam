using Microsoft.EntityFrameworkCore;
using MilestoneExam.Data.Models;
using MilestoneExam.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IMainDataContext context) : base(context) { }

        public override async Task<Customer> FirstOrDefaultAsync(Expression<Func<Customer, bool>> predicate = null)
        {
            return await Query(predicate).Include(c => c.Purchases).FirstOrDefaultAsync();
        }
    }
}
