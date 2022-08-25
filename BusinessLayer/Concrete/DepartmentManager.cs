using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentManager(IDepartmentRepository _departmentRepository)
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

        public void TAdd(Department entity)
        {
            departmentRepository.Create(entity);
        }

        public void TDelete(Department entity)
        {
            departmentRepository.Delete(entity);
        }

        public Department TGetById(int id)
        {
            return departmentRepository.GetById(id);
        }

        public void TUpdate(Department entity)
        {
            departmentRepository.Update(entity);
        }
    }
}
