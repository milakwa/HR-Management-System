using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class Developer : Employee
    {
        public Developer(int id, string name, string department, decimal salary) 
            : base(id, name, department, salary)
        {
        }
        // Developers might have overtime pay
        public override decimal CalculatePay(double hoursWorked)
        {
            double normalHours = 160; // Assuming 160 hours as standard monthly hours

            decimal hourlyRate = (GetSalary() / (decimal)normalHours); // Hourly rate based on monthly salary

            decimal overtimeRate = 1.5m; // Overtime pay rate

            decimal overtimePay = hourlyRate * overtimeRate; // Overtime hourly pay

            if (hoursWorked < 0)
            {
                throw new Exception("Hours worked cannot be negative!");
            }
            double overtime = hoursWorked > normalHours ? hoursWorked - normalHours : 0; // Overtime hours worked

            decimal totalPay = GetSalary(); // Base salary

            totalPay += (decimal)(overtime * (double)overtimePay); // Add overtime pay if any

            return totalPay;



        }
        public void DoWork()
        {
            Console.WriteLine($"{Name} is working....");
        }

    }
    
}
