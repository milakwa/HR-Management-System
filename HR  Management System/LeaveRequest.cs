using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class LeaveRequest
    {
       public int EmpId { get; set; }
       public int Days { get; set; }
       public string Reason { get; set; }
       public string Status { get; set; }

        public LeaveRequest(int id,int days,string reason,string status)
        {
            EmpId = id;
            Days = days;
            Reason = reason;
            Status = "Pending";
        }
        public void Approve()
        {
            Status = "Approved";
        }
        public void Reject()
        {
            Status = "Rejected";
        }

    }
}
