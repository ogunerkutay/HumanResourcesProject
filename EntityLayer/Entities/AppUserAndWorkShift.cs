using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUserAndWorkShift
    {
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }

        public WorkShift WorkShift { get; set; }
        public int WorkShiftID { get; set; }
    }
}
