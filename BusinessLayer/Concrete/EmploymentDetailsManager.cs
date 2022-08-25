using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmploymentDetailsManager : IEmploymentDetailsService
    {
        private readonly IEmploymentDetailsRepository employmentDetailsRepository;

        public EmploymentDetailsManager(IEmploymentDetailsRepository _employmentDetailsRepository)
        {
            employmentDetailsRepository = _employmentDetailsRepository;
        }

        public void Add(EmploymentDetails entity)
        {
            employmentDetailsRepository.Create(entity);
        }

        public void Delete(EmploymentDetails entity)
        {
            employmentDetailsRepository.Delete(entity);
        }

        public List<EmploymentDetails> GetAll()
        {
            return employmentDetailsRepository.GetAll();
        }

        public EmploymentDetails GetById(int id)
        {
            return employmentDetailsRepository.GetById(id);
        }

        public List<EmploymentDetails> GetListById(int id)
        {
            return employmentDetailsRepository.GetListFilter(x=>x.EmploymentDetailsID==id);
        }

        public void Update(EmploymentDetails entity)
        {
            employmentDetailsRepository.Update(entity);
        }
    }
}
