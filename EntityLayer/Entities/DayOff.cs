using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DayOff
    {
        public int DayOffID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool DepartmentApproval { get; set; }
        public bool ManagerApproval { get; set; }
        public string Description { get; set; }

        public AppUser AppUser { get; set;}
        public int AppUserID { get; set; }
       
    }
}
