using BusinessLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.VMs
{
    public class AppUserDetailsandEmployeesVM
    {
        public AppUserDetailsVM appUserDetailsVM { get; set; }
        
        public List<AppUserVM> employeeList { get; set; }
    }
}
