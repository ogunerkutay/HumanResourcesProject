using DataAccessLayer.IRepositories;
using EntityLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext appDbContext;
        protected DbSet<T> table;
        public GenericRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
            table = _appDbContext.Set<T>();
        }
        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await table.AnyAsync(expression);
        }
        /// <summary>
        /// bu method bool döner
        /// </summary>
        /// <param name="entity">Oluşturulacak kişiyi alır.</param>
        /// <returns></returns>
        public async Task<bool> Create(T entity)
        {
            if(entity != null)
            {
            table.Add(entity);
            int isChanged =  await appDbContext.SaveChangesAsync();
                if (isChanged > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
            appDbContext.SaveChanges();
        }

        public async Task<List<T>> GetAllWhere(Expression<Func<T, bool>> expression)
        {
            return await table.Where(expression).ToListAsync();
        }

        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = table;
            if (includes != null) query = includes(query);
            if (expression != null) query = query.Where(expression);
            if (orderBy != null)
            {
                return await orderBy(query).Select(selector).FirstOrDefaultAsync();
            }
            else return await query.Select(selector).FirstOrDefaultAsync();
        }

        public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null, int? take = null)
        {
            IQueryable<T> query = table;
            if (includes != null) query = includes(query);
            if (expression != null) query = query.Where(expression);
            if (orderBy != null)
            {
                if (take != null)
                {
                    return await orderBy(query).Select(selector).Take((int)take).ToListAsync();
                }
                return await orderBy(query).Select(selector).ToListAsync();
            }
            else {
                if(take != null)
                {
                    return await query.Select(selector).Take((int)take).ToListAsync();
                }
                return await query.Select(selector).ToListAsync();
            }
               
        }

        public async Task<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return await table.FirstOrDefaultAsync(expression);
        }

        public void Update(T entity)
        {
            //table.Update(entity);
            appDbContext.Entry<T>(entity).State = EntityState.Modified;
            appDbContext.SaveChanges();
        }
    }
}
