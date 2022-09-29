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

namespace BusinessLayer.Services.EmploymentDetailsService
{
    public class EmploymentDetailsService : IEmploymentDetailsService
    {
        private readonly IEmploymentDetailsRepository employmentDetailsRepository;

        public EmploymentDetailsService(IEmploymentDetailsRepository _employmentDetailsRepository)
        {
            employmentDetailsRepository = _employmentDetailsRepository;
        }

        public Task<bool> Any(Expression<Func<EmploymentDetails, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task Create(EmploymentDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(EmploymentDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmploymentDetails>> GetAllWhere(Expression<Func<EmploymentDetails, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<EmploymentDetails, TResult>> selector, Expression<Func<EmploymentDetails, bool>> expression, Func<IQueryable<EmploymentDetails>, IOrderedQueryable<EmploymentDetails>> orderBy = null, Func<IQueryable<EmploymentDetails>, IIncludableQueryable<EmploymentDetails, object>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<EmploymentDetails, TResult>> selector, Expression<Func<EmploymentDetails, bool>> expression, Func<IQueryable<EmploymentDetails>, IOrderedQueryable<EmploymentDetails>> orderBy = null, Func<IQueryable<EmploymentDetails>, IIncludableQueryable<EmploymentDetails, object>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<EmploymentDetails> GetWhere(Expression<Func<EmploymentDetails, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(EmploymentDetails entity)
        {
            throw new NotImplementedException();
        }

        Task<object> IGenericService<EmploymentDetails>.Create(EmploymentDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
