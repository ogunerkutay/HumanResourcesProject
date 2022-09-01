using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class DepartmentAndWorkShift
    {
        
        public int DepartmentAndWorkShiftID { get; set; }
        public DateTime WorkDate { get; set; }


        public int WorkShiftID { get; set; }
        public int DepartmentID { get; set; }
        
        public Department Department { get; set; }
        public WorkShift WorkShift { get; set; }
    }
}
