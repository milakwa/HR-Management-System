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

            if (totalPay == 0)
            {
                Console.WriteLine($"\nCould not calculate salary for {emp.Name} (ID={emp.Id}). Please check hours worked.\n");
                Logger.WriteLog("PAYROLL", $"Failed salary calculation for {emp.Name} (ID={emp.Id})");
                return 0;
            }

            // Log the payroll calculation
            string role = emp.GetType().Name;

            Logger.WriteLog("PAYROLL",$"Calculated salary for {role} [ID={emp.Id}, Name={emp.Name}]: {totalPay:C} for {hoursWorked} hours worked.");
            Console.WriteLine($"Salary for {emp.Name} ({role}) = {totalPay:C}");

            return totalPay;
            
        }
    }
}
