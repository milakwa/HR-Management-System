using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{  
    /*public class Payroll
   {
      public bool CalculateSalary(Employee emp, double hoursWorked, out decimal totalPay)
      {
        totalPay = emp.CalculatePay(hoursWorked);

        if (totalPay == 0)
        {
            Console.WriteLine($"❌ Error: Failed to calculate salary for Employee ID={emp.Id}. Check hours worked.");
            Logger.WriteLog("PAYROLL", $"Failed salary calculation for {emp.Name} (ID={emp.Id})");
            return false; // فشل
        }

        string role = emp.GetType().Name;
        Logger.WriteLog("PAYROLL",
            $"Calculated salary for {role} [ID={emp.Id}, Name={emp.Name}]: {totalPay:C} for {hoursWorked} hours worked.");
        return true; // نجاح
      }
    }*/

    public class Payroll
    {
        public decimal CalculateSalary(Employee emp,double hoursWorked)
        {
            decimal totalPay = emp.CalculatePay(hoursWorked); 

            if (totalPay == 0)
            {
                Console.WriteLine($"Could not calculate salary for {emp.Name} (ID={emp.Id}). Please check hours worked.");
                Logger.WriteLog("PAYROLL", $"Failed salary calculation for {emp.Name} (ID={emp.Id})");
                return 0;
            }

            string role = emp.GetType().Name;

            Logger.WriteLog("PAYROLL",$"Calculated salary for {role} [ID={emp.Id}, Name={emp.Name}]: {totalPay:C} for {hoursWorked} hours worked.");
            Console.WriteLine($"Salary for {emp.Name} ({role}) = {totalPay:C}");

            return totalPay;
            
        }
    }
}
