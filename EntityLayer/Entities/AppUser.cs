using EntityLayer.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser: IdentityUser <int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNO { get; set; }
        public string ImagePath { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public double GrossSalary { get; set; }

        public Department Department { get; set; }
        public int DepartmentID { get; set; }
        public List<DayOff> DayOffs { get; set; }
        public List<Overtime> Overtimes { get; set; }
        
        public List<WorkHour> WorkHours { get; set; }

        public List<EmploymentDetails> EmploymentDetails { get; set; }
        public List<Debit> Debits { get; set; }
        
    }
}
