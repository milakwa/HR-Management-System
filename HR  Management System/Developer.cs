using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{

    // Developer class inheriting from Employee
    public class Developer : Employee
    {
        public Developer(int id, string name, Department department, decimal salary) 
            : base(id, name, department, salary)
        {
        }
        // Developers might have overtime pay
        public override decimal CalculatePay(double hoursWorked)
        {
            if (hoursWorked < 0)
            {
                Console.WriteLine("Hours worked cannot be negative!");

                Logger.WriteLog("PAYROLL", $"Failed to calculate pay for {Name} (ID={Id})");
                return 0;
            } 

            double normalHours = 160;// Assuming 160 hours as standard monthly hours

            decimal hourlyRate = GetSalary() / (decimal)normalHours;// Hourly rate based on monthly salary

            decimal overtimeRate = 1.5m;// Overtime pay rate

            double workedNormal = Math.Min(hoursWorked, normalHours);// Normal hours worked

            double overtimeHours = hoursWorked > normalHours ? hoursWorked - normalHours : 0;// Overtime hours worked

            decimal basePay = hourlyRate * (decimal)workedNormal;// Pay for normal hours
            decimal overtimePay = hourlyRate * overtimeRate * (decimal)overtimeHours;// Pay for overtime hours
            decimal totalPay = basePay + overtimePay;// Total pay including overtime

            Logger.WriteLog("PAYROLL", $"Developer {Name} (ID={Id}) calculated pay: {totalPay:C} (Base: {basePay:C}, Overtime: {overtimePay:C} for {overtimeHours}h)");
            
            return totalPay;

        }

        public void DoWork()
        {
            Console.WriteLine($"{Name} is working....");

            Logger.WriteLog("WORK", $"Developer {Name} (ID={Id}) is doing work.");
        }

    }
    
}

