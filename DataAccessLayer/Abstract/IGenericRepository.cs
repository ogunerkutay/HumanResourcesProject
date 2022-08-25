using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        List<T> GetListFilter(Expression<Func<T, bool>> filter);

        void Create(T entity);
        void Update(T entity); 
        void Delete(T entity);
    }
}

    