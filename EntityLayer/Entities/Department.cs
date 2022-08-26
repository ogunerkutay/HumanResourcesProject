using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserID { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
