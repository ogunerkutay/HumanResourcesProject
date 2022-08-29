using BusinessLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.VMs
{
    public class AppUserandDepartments
    {
        public AppUserUpdateDTO appUserUpdateDTO { get; set; }
        public List<GetDepartmentsVM> departmentsList { get; set; }

      
    }
}
