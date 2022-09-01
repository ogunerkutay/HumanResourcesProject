using BusinessLayer.Models.VMs;
using BusinessLayer.Services.GenericService;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.DepartmentService
{
    public interface IDepartmentService : IGenericService<Department>
    {
        Task<List<GetDepartmentsVM>> GetAllDepartments();

    }
}
