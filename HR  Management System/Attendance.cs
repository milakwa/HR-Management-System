using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public  class Attendance
    {
        // Properties
        public int EmployeeID { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public DateTime Date { get; set; }

        // Constructor
        public Attendance(int employeeId)
        {
            EmployeeID = employeeId;
            Date = DateTime.Today;
        }

        // Static methods for check-in and check-out
        public static bool CheckIn(int empId, List<Attendance> records)
        {
            // Prevent multiple check-ins without check-out
            if (records.Any(a => a.EmployeeID == empId && a.Date == DateTime.Today))
            {
                if (records.Any(a => a.EmployeeID == empId && a.Date == DateTime.Today && a.CheckOutTime == default))
                {
                    Console.WriteLine("\nAlready checked in today without checking out!");
                    Logger.WriteLog("ATTENDANCE", $"Failed checkin attempt for EmpId={empId} (Already checked in)");
                    return false;
                }
                else
                {
                    Console.WriteLine("\nAlready checked in and checked out today. Cannot check in again today!");
                    Logger.WriteLog("ATTENDANCE", $"Failed checkin attempt for EmpId={empId} (Already checked in and out today)");
                    return false;
                }
            }
            // Create new attendance record
            Attendance record = new Attendance(empId);
            record.CheckInTime = DateTime.Now;
            records.Add(record);

            // Display confirmation
            Console.WriteLine($"\nEmployee {empId} checked in at {record.CheckInTime} (Date: {record.Date:yyyy-MM-dd})");
            Logger.WriteLog("ATTENDANCE", $"Employee {empId} checked in at {record.CheckInTime} (Date: {record.Date:yyyy-MM-dd})");

            return true;
        }

        public static bool CheckOut(int empId, List<Attendance> records)
        {
            // Find today's record with no checkout time

            var record = records.LastOrDefault(a => a.EmployeeID == empId && a.Date == DateTime.Today && a.CheckOutTime == default);

            if (record == null)
            {
                Console.WriteLine("\nNo active check-in found for today OR already checked out.");
                Logger.WriteLog("ATTENDANCE", $"Failed checkout attempt for EmpId={empId} (No active check-in or already checked out)");
                return false;
            }
            // Ask user for real time or manual hours
            // Loop until valid choice
            string choice;
            do
            {
                Console.Write("\nUse real time (R) or enter hours manually (M)? ");
                choice = Console.ReadLine().Trim().ToUpper();

                if (choice == "M")
                {
                    Console.Write("Enter number of hours worked today: ");
                    if (!double.TryParse(Console.ReadLine(), out double hours) || hours <= 0)
                    {
                        Console.WriteLine("\nInvalid hours. Checkout failed.");
                        return false;
                    }
                    record.CheckOutTime = record.CheckInTime.AddHours(hours);
                }
                else if (choice == "R")
                {
                    record.CheckOutTime = DateTime.Now;
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Try again.");
                }
            } while (choice != "M" && choice != "R");

            // Validate checkout time
            double workedHours = (record.CheckOutTime - record.CheckInTime).TotalHours;

            Console.WriteLine($"\nEmployee {empId} checked out at {record.CheckOutTime} (Date: {record.Date:yyyy-MM-dd})");
            Logger.WriteLog("ATTENDANCE", $"Employee {empId}  checked out at  {record.CheckOutTime} (Date: {record.Date:yyyy-MM-dd})");

            return true;

        }
        // Calculate total hours worked
        public double GetTotalHours()
        {
            // Validate times
            if (CheckInTime == default || CheckOutTime == default)
            {
                Console.WriteLine($"\nIncomplete attendance record for Employee {EmployeeID}");
                Logger.WriteLog("ATTENDANCE", $"Incomplete attendance record for EmpId={EmployeeID}");
                return 0;
            }
              
            if (CheckOutTime < CheckInTime)
            {
                Console.WriteLine("\nCheck-out time cannot be before check-in time!");
                Logger.WriteLog("ATTENDANCE", $"Invalid times for EmpId={EmployeeID} (CheckOut before CheckIn)");
                return 0;
            }
            // Calculate hours
            double hours = (CheckOutTime - CheckInTime).TotalHours;
          
            Console.WriteLine($"\nEmployee {EmployeeID} worked {hours:F2} hours.\n");
            Logger.WriteLog("ATTENDANCE", $"Employee {EmployeeID} worked for {hours:F2} hours.");

            return hours;
        }
    }
}
