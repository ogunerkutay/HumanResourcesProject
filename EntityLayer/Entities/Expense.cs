using EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Expense
    {
        public int ExpenseID { get; set; }
        public DateTime DemandDate { get; set; }
        public string ExpenseDescription { get; set; }
        public Urgency Urgency { get; set; }
        public double TotalPrice {get; set; }
        public bool ManagerApproval { get; set; }
        public int Quantity { get; set; }
        public Department Department { get; set; }
        public int DepartmentID { get; set; }
    }
}
