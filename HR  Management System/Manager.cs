using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class Manager : Employee 
    {
        public Manager(int id, string name, string department, decimal salary) 
            : base(id, name, department, salary) 
        {
        }
        // Managers might have a different pay calculation , fixed salary plus bonus
        public override decimal CalculatePay(double hoursWorked)
        {
            if (hoursWorked < 0)
            {
                Console.WriteLine("Hours worked cannot be negative!");
                Logger.WriteLog("PAYROLL", $"Failed to calculate pay for {Name} (ID={Id})");
                return 0;
            }

            decimal basePay =base.CalculatePay(hoursWorked); // Base salary
            decimal bonus = 1000; // Example fixed bonus for managers
            decimal totalPay = basePay + bonus; // Total pay including bonus

            Logger.WriteLog("PAYROLL", $"Manager {Name} (ID={Id}) calculated pay: {totalPay:C} (Base: {basePay:C} + Bonus: {bonus:C})");

            return totalPay;
        }
        public void ApproveLeave(LeaveRequest request)
        {
            request.Approve();
            Console.WriteLine($"Leave request for Employee ID {request.EmpId} has been approved.");

            Logger.WriteLog("LEAVE", $"Manager {Name} (ID={Id}) approved leave for Employee {request.EmpId}");
        }
        public void RejectLeave(LeaveRequest request)
        {
            request.Reject();
            Console.WriteLine($"Leave request for Employee ID {request.EmpId} has been rejected.");

            Logger.WriteLog("LEAVE", $"Manager {Name} (ID={Id}) rejected leave for Employee {request.EmpId}");
        }


    }
}
