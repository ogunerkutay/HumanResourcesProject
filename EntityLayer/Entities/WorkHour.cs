using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WorkHour
    {
        public int WorkHourID { get; set; }
        public string AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
