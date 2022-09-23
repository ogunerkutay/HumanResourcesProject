using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class DayOff
    {
        public int DayOffID { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime ReturnDate { get; set; }
        public bool DepartmentApproval { get; set; }
        public bool ManagerApproval { get; set; }
        public string Description { get; set; }

        public AppUser AppUser { get; set;}
        public int AppUserID { get; set; }
       
    }
}
