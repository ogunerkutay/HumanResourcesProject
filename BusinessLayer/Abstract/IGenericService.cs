using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<TEntity>
    {
        void TAdd(TEntity entity);
        void TDelete(TEntity entity);
        void TUpdate(TEntity entity);
        List<TEntity> GetAll();
        TEntity TGetById(int id);
    }
}
