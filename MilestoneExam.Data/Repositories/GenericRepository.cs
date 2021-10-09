using Microsoft.EntityFrameworkCore;
using MilestoneExam.Data.Models.Interfaces;
using MilestoneExam.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private IMainDataContext Context { get; }

        public GenericRepository(IMainDataContext context) 
        {
            Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            //Async to add auditable info later
            Context.Set<TEntity>().Add(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Query(predicate).AnyAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            //Async to add auditable info later
            Context.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity> FindAsync(long id)
        {
            if (!typeof(TEntity).GetInterfaces().Contains(typeof(ISingleKeyModel)))
                throw new Exception($"Repository.FindAsync requires {typeof(TEntity).Name} to implement {typeof(ISingleKeyModel).Name}");

            var query = (IQueryable<ISingleKeyModel>)Query();

            return (TEntity)await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Query(predicate).FirstOrDefaultAsync();
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return Query(predicate).SingleOrDefaultAsync();
        }

        public Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return Query(predicate).ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity, object newEntityData)
        {
            //Async to add auditable info later
            Context.Entry(entity).CurrentValues.SetValues(newEntityData);
        }

        protected IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = Context.Set<TEntity>().AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }
    }
}
