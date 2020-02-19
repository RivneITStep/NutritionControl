using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Repository
{
    public class GenericRepository<TEntity>
    : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly DbContext _db;
        private readonly DbSet<TEntity> _set;

        public GenericRepository(DbContext db)
        {
            _db = db;
            _set = _db.Set<TEntity>();
        }

        public async Task<int> CountAll() => await _set.CountAsync();


        public async Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate)
          => await _set.CountAsync(predicate);

        public async Task<TEntity> Create(TEntity entity)
        {
            var entry = await _set.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<TEntity>> Create(IEnumerable<TEntity> entities)
        {
            List<TEntity> added = new List<TEntity>();
            EntityEntry<TEntity> entry;

            foreach (var item in entities)
            {
                entry = await _set.AddAsync(item);
                added.Add(entry.Entity);
            }
            await _db.SaveChangesAsync();

            return added;
        }

        public async Task Delete(TEntity entity)
        {
            _set.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(IEnumerable<TEntity> entity)
        {
            _set.RemoveRange(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<TEntity> Find(int Id)
        {
            return await _set.FindAsync(Id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _set.ToListAsync();
        }

        public IQueryable<TEntity> GetAsQueryable()
        {
            return _set.AsQueryable();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await _set.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllInclude(params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes.Aggregate(_set.AsQueryable(),
                (current, includeProperty) =>
                    current.Include(includeProperty)).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes.Aggregate(_set.Where(predicate),
                (current, includeProperty) =>
                    current.Include(includeProperty)).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetPaged(int startIndex, int count, params Expression<Func<TEntity, object>>[] includes)
        {
            startIndex = startIndex - 1;
            return await includes.Aggregate(_set.AsQueryable(),
                (current, includeProperty) =>
                    current.Include(includeProperty)).Skip(startIndex * count).Take(count).ToListAsync();
        }

        public async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _set.AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query,
                (current, includeProperty) =>
                    current.Include(includeProperty));
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TResult>> GetAllSelect<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                                      Expression<Func<TEntity, bool>> predicate = null,
                                                                      params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _set.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includes != null)
            {
                query = includes.Aggregate(query,
                (current, includeProperty) =>
                    current.Include(includeProperty));
            }

            return await query.Select(selector).ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}