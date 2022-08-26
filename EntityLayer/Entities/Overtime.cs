using EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Overtime
    {
        public int OvertimeID { get; set; }
        public DateTime DermandDate { get; set; }
        public string OvertimeDescription { get; set; }
        public Urgency Urgency { get; set; }
        public double ManHour { get; set; }
        public bool ManagerApproval { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserID { get; set; }

    }
}
