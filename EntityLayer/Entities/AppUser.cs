using EntityLayer.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string TCNO { get; set; }
        public string ImagePath { get; set; }
        public Gender Gender { get; set; }
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        //[Column(TypeName = "Date")] database silindiğinde aktif yapalım!!!!!!!!!!!!!!!!!!!!!
        public DateTime EmploymentDate { get; set; }
        public int AnnualLeave { get; set; } //özlük hakkı
        public int remainingDayOff { get; set; }
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
