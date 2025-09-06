using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class Manager : Employee 
    {
        public Manager(int id, string name, string department, decimal salary) : base(id, name, department, salary)
        {
        }
        // Managers might have a different pay calculation , fixed salary plus bonus
        public override decimal CalculatePay(double hoursWorked)
        {
            if (hoursWorked < 0)
            {
                throw new Exception("Hours worked cannot be negative!");
            }

            decimal bonus = 1000; // Example fixed bonus for managers
            return GetSalary() + bonus;
        }
        public void ApproveLeave(LeaveRequest request)
        {
            request.Approve();
            Console.WriteLine($"Leave request for Employee ID {request.EmpId} has been approved.");
        }
        public void RejectLeave(LeaveRequest request)
        {
            request.Reject();
            Console.WriteLine($"Leave request for Employee ID {request.EmpId} has been rejected.");
        }


    }
}
