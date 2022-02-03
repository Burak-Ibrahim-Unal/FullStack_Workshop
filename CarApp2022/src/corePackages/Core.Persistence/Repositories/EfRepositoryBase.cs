using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>, ISyncRepository<TEntity>
        where TEntity : Entity
        where TContext : DbContext
    {

        protected TContext Context { get; }

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }


        #region Async Codes
        // Async Codes
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate); // find first record...
        }

        public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity,
            bool>> predicate = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int index = 0, int size = 10, bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);

            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);


        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added; // entity framework tracking
            await Context.SaveChangesAsync();
            return entity;

        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted; // entity framework tracking
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified; // entity framework tracking
            await Context.SaveChangesAsync();
            return entity;
        } 
        #endregion

        #region Sync Codes
        // Sync Codes
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int index = 0, int size = 10,
            bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) return orderBy(queryable).ToPaginate(index, size);


            return queryable.ToPaginate(index, size);
        }

        public TEntity Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
            return entity;
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
        }
        #endregion
    }
}
