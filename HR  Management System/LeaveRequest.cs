using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class LeaveRequest
    {
        // Properties of a leave request
       public int EmpId { get; set; }
       public int Days { get; set; }
       public string Reason { get; set; }
       public string Status { get; set; }
        // Constructor
        public LeaveRequest(int id,int days,string reason)
        {
            EmpId = id;
            Days = days;
            Reason = reason;
            Status = "Pending";

            Logger.WriteLog("LEAVE", $"New leave request created for EmpId={EmpId}, Days={Days}, Reason={Reason}, Status={Status}");
        
        }
        // Methods to approve or reject the leave request
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
