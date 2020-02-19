using NutritionControl.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NutritionControl.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        Task<TEntity> Create(TEntity entity);
        Task<IEnumerable<TEntity>> Create(IEnumerable<TEntity> entities);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(IEnumerable<TEntity> entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllInclude(params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetAllInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TResult>> GetAllSelect<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                         Expression<Func<TEntity, bool>> predicate = null,
                                                         params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> Find(int Id);
        Task<IEnumerable<TEntity>> GetPaged(int startIndex, int count, params Expression<Func<TEntity, object>>[] includes);
        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAsQueryable();
    }
}