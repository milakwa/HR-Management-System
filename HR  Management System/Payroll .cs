using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class Payroll
    {
        // Calculate salary based on hours worked
        public decimal CalculateSalary(Employee emp,double hoursWorked)
        {
            decimal totalPay = emp.CalculatePay(hoursWorked);

            string role = emp.GetType().Name; // Get the role of the employee (e.g., Manager, Developer)

            if (totalPay == 0)
            {
                Console.WriteLine($"\nSalary for {emp.Name} ({role}, ID={emp.Id}) is 0. Please check hours worked or salary.\n");
                Logger.WriteLog("PAYROLL", $"Salary calculation resulted in 0 for {emp.Name} ({role}, ID={emp.Id})");
                return 0;
            }

            // Log the payroll calculation
            Console.WriteLine($"Salary for {emp.Name} ({role}) = {totalPay:C}");
            Logger.WriteLog("PAYROLL", $"Calculated salary for {role} [ID={emp.Id}, Name={emp.Name}]: {totalPay:C} for {hoursWorked} hours worked.");

            return totalPay;

        }
    }
}
