using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class EmploymentDetails
    {
        public int EmploymentDetailsID { get; set; }
        //[Column(TypeName = "Date")]
        public DateTime EmploymentDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DismissalDate { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserID { get; set; }
    }
}
