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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IMainDataContext context) : base(context) { }

        public override async Task<Product> FirstOrDefaultAsync(Expression<Func<Product, bool>> predicate = null)
        {
            return await Query(predicate).Include(p => p.Purchases).FirstOrDefaultAsync();
        }
    }
}
