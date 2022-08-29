using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.VMs
{
    public class AppUserDetailsVM
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
        public List<DayOff> DayOffs { get; set; }
        public Department Department { get; set; }
        
        public List<WorkHour> WorkHours { get; set; }
        public List<EmploymentDetails> EmploymentDetails { get; set; }
    }
}
