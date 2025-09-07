using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
  public  class Manager : Employee 
  {
      // Managers have all Employee properties and methods
      public Manager(int id, string name, Department department, decimal salary)
          : base(id, name, department, salary) 
      {
      }
      // Managers might have a different pay calculation , fixed salary plus bonus
      public override decimal CalculatePay(double hoursWorked)
      {
          if (hoursWorked < 0)
          {
              Console.WriteLine("\nHours worked cannot be negative!");
              Logger.WriteLog("PAYROLL", $"Failed to calculate pay for {Name} (ID={Id})");
              return 0;
          }

          decimal basePay =base.CalculatePay(hoursWorked); // Base salary
          decimal bonus = 1000; // Example fixed bonus for managers
          decimal totalPay = basePay + bonus; // Total pay including bonus

          Logger.WriteLog("PAYROLL", $"Manager {Name} (ID={Id}) calculated pay: {totalPay:C} (Base: {basePay:C} + Bonus: {bonus:C})");

          return totalPay;
      }
      // Managers can approve or reject leave requests
      public void ApproveLeave(LeaveRequest request)
      {
          request.Approve();
          Console.WriteLine($"\nLeave request for Employee ID {request.EmpId} has been approved.");

          Logger.WriteLog("LEAVE", $"Manager {Name} (ID={Id}) approved leave for Employee {request.EmpId}");
      }
      // Managers can approve or reject leave requests
      public void RejectLeave(LeaveRequest request)
      {
          request.Reject();
          Console.WriteLine($"\nLeave request for Employee ID {request.EmpId} has been rejected.");

          Logger.WriteLog("LEAVE", $"Manager {Name} (ID={Id}) rejected leave for Employee {request.EmpId}");
      }
      // Managers can review a list of leave requests
      public void ReviewLeaveRequests(List<LeaveRequest> requests)
      {
          // Filter only pending requests
          var pendingRequests = requests.Where(r => r.Status == "Pending").ToList();

          if (pendingRequests.Count == 0)
          {
              Console.WriteLine("\nNo pending leave requests.");
              return;
          }
          // Display and process each pending request
          foreach (var req in pendingRequests)
          {
              Console.WriteLine($"\nRequest: EmpId={req.EmpId}, Days={req.Days}, Reason={req.Reason}, Status={req.Status}");
              while (true)
              {
                  Console.Write("\nApprove (A) / Reject (R): ");
                  string input = Console.ReadLine().Trim().ToUpper();
                  if (input != "A" && input != "R")
                  {
                      Console.WriteLine("\nInvalid input. Try again.\n");
                      continue;
                  }

                  if (input == "A")
                  {
                      this.ApproveLeave(req);
                      break;
                  }
                  else if (input == "R")
                  {
                      this.RejectLeave(req);
                      break;
                  }

              }

          }
          Console.WriteLine("\nYou have completed the pending leave requests.");
          Logger.WriteLog("LEAVE", $"Manager {Name} (ID={Id}) reviewed leave requests.");
      }
  }
}
