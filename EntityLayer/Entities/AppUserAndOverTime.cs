using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUserAndOverTime
    {
        public string AppUserID { get; set; }
        public AppUser AppUser { get; set; }

        public Overtime Overtime { get; set; }
        public int OvertimeID { get; set; }
    }
}
