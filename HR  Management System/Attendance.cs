using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public  class Attendance
    {
        public int EmployeeID { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }


        public bool CheckIn(int employeeId)
        {
            if (CheckInTime != default && CheckOutTime == default)
            {
                Console.WriteLine("Already checked in and not checked out yet!");
                Logger.WriteLog("ATTENDANCE", $"Failed check-in attempt for EmpId={employeeId} (Already checked in)");
                return false;
            }

            EmployeeID = employeeId;
            CheckInTime = DateTime.Now;
            CheckOutTime = default; // Reset check-out time

            Console.WriteLine($"Employee {EmployeeID} checked in at {CheckInTime}");
            Logger.WriteLog("ATTENDANCE", $"Employee {EmployeeID} checked in at {CheckInTime}");

            return true;
        }
        public bool CheckOut()
        {
            if (CheckInTime == default)
            {
                Console.WriteLine("Cannot check out before check in!");
                Logger.WriteLog("ATTENDANCE", $"Failed checkout attempt for EmpId={EmployeeID} (No CheckIn)");
                return false;
            }

            if (CheckOutTime != default)
            {
                Console.WriteLine("Already checked out!");
                Logger.WriteLog("ATTENDANCE", $"Failed checkout attempt for EmpId={EmployeeID} (Already checked out)");
                return false;
            }

            CheckOutTime = DateTime.Now;

            Console.WriteLine($"Employee {EmployeeID} checked out at {CheckOutTime}");
            Logger.WriteLog("ATTENDANCE", $"Employee {EmployeeID} checked out at {CheckOutTime}");

            return true;
        }

        public double GetTotalHours()
        {
            if (CheckInTime == default || CheckOutTime == default)
            {
                Console.WriteLine($"Incomplete attendance record for Employee {EmployeeID}");
                Logger.WriteLog("ATTENDANCE", $"Incomplete attendance record for EmpId={EmployeeID}");
                return 0;
            }
              
            if (CheckOutTime < CheckInTime)
            {
                Console.WriteLine("Check-out time cannot be before check-in time!");
                Logger.WriteLog("ATTENDANCE", $"Invalid times for EmpId={EmployeeID} (CheckOut before CheckIn)");
                return 0;
            }

            double hours = (CheckOutTime - CheckInTime).TotalHours;
          
            Console.WriteLine("Employee {EmployeeID} worked {hours:F2} hours.");
            Logger.WriteLog("ATTENDANCE", $"Employee {EmployeeID} worked for {hours:F2} hours.");

            return hours;
        }
    }
}
