using BusinessLayer.Services.GenericService;
using DataAccessLayer.IRepositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.DayOffService
{
    public class DayOffService : IDayOffService
    {
        private readonly IDayOffRepository dayOffRepository;

        public DayOffService(IDayOffRepository _dayOffRepository)
        {
            dayOffRepository = _dayOffRepository;
        }

        public Task<bool> Any(Expression<Func<DayOff, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task Create(DayOff entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(DayOff entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<DayOff>> GetAllWhere(Expression<Func<DayOff, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<DayOff, TResult>> selector, Expression<Func<DayOff, bool>> expression, Func<IQueryable<DayOff>, IOrderedQueryable<DayOff>> orderBy = null, Func<IQueryable<DayOff>, IIncludableQueryable<DayOff, object>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<DayOff, TResult>> selector, Expression<Func<DayOff, bool>> expression, Func<IQueryable<DayOff>, IOrderedQueryable<DayOff>> orderBy = null, Func<IQueryable<DayOff>, IIncludableQueryable<DayOff, object>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<DayOff> GetWhere(Expression<Func<DayOff, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(DayOff entity)
        {
            throw new NotImplementedException();
        }

        Task<object> IGenericService<DayOff>.Create(DayOff entity)
        {
            throw new NotImplementedException();
        }
    }
}
