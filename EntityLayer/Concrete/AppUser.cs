using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TCNO { get; set; }
        public string ImagePath { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public double GrossSalary { get; set; }
        public List<DayOff> DayOffs { get; set; }
        public List<Department> Departments { get; set; }
        public List<WorkHour> WorkHours { get; set; }
        public List<EmploymentDetails> EmploymentDetails { get; set; }
    }
}
