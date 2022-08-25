using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext appDbContext;
        protected DbSet<TEntity> table;
        public GenericRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
            table = _appDbContext.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            table.Add(entity);
            appDbContext.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            table.Remove(entity);
            appDbContext.SaveChanges();
        }
        public List<TEntity> GetAll()
        {
            return table.ToList();
        }
        public TEntity GetById(int id)
        {

            return table.Find(id);
        }
        public List<TEntity> GetListFilter(Expression<Func<TEntity, bool>> filter)
        {
            return table.Where(filter).ToList();

        }
        public void Update(TEntity entity)
        {
            table.Update(entity);
            appDbContext.SaveChanges();
        }
    }
}
