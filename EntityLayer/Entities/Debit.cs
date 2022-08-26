using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Debit
    {
        public int DebitID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime GivenDate { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserID { get; set; }

    }
}
