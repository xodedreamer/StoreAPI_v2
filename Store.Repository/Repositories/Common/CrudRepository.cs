﻿using Microsoft.EntityFrameworkCore;
using Store.Domain.Constants;
using Store.Domain.Interfaces.Repositories.Common;
using Store.Domain.Models.Common;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Repository.Repositories.Common
{
    public abstract class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : Entity
    {
        protected DbContext context;
        protected DbSet<TEntity> set;

        public CrudRepository(DbContext context)
        {
            this.context = context;
            set = this.context.Set<TEntity>();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);

            if (entity == null)
                return;

            set.Remove(entity);
        }

        public virtual async Task<TEntity> GetAsync(Guid id) => await Query().FirstOrDefaultAsync(x => x.Id == id);

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => await Query().FirstOrDefaultAsync(predicate);

        public virtual IQueryable<TEntity> Query() => set.AsQueryable();

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate) => set.Where(predicate);

        public virtual async Task SaveAsync(TEntity entity)
        {
            if (entity.Id == null || entity.Id == Guid.Empty)
                await set.AddAsync(entity);
            else
                context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<bool> AnyAsync(Guid id) => await Query(e => e.Id == id).AnyAsync();

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) => await Query(predicate).AnyAsync();

        public virtual async Task AddAsync(TEntity entity) => await set.AddAsync(entity);

        public virtual async Task UpdateAsync(TEntity entity) => set.Update(entity);

        public virtual PagedResult<TEntity> Page(IQueryable<TEntity> query, int page, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var totalItems = query.Count();
            return new PagedResult<TEntity>(
                page,
                (int)Math.Ceiling(totalItems / (decimal)pageSize),
                totalItems,
                query.Skip((page - 1) * pageSize).Take(pageSize).ToList()
            );
        }

        public virtual PagedResult<TEntity> Page(Expression<Func<TEntity, bool>> predicate, int page, int pageSize = GlobalConstants.DefaultPageSize) => Page(Query(predicate), page, pageSize);

        public virtual void Dispose() => context.Dispose();
    }
}
