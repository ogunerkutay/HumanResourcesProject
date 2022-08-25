using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository _departmentRepository)
        {
            departmentRepository = _departmentRepository;
        }
        public List<Department> GetAll()
        {
            return departmentRepository.GetAll();

        }
        public List<Department> GetListById(int id)
        {
            return departmentRepository.GetListFilter(x => x.DepartmentID == id);
        }

        public void Add(Department entity)
        {
            departmentRepository.Create(entity);
        }

        public void Delete(Department entity)
        {
            departmentRepository.Delete(entity);
        }

        public Department GetById(int id)
        {
            return departmentRepository.GetById(id);
        }

        public void Update(Department entity)
        {
            departmentRepository.Update(entity);
        }
    }
}
