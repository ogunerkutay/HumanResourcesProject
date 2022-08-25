using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WorkShift
    {
        public int WorkShiftID { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BreakTimeStart { get; set; }
        public DateTime BreakTimeEnd { get; set; }
    }
}
