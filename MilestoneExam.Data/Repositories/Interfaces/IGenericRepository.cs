using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Data.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task<TEntity> FindAsync(long id);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task DeleteAsync(TEntity entity);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity, object newEntityData);
    }
}
