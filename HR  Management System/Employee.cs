using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class Employee
    {
        // Basic employee properties
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }

        private decimal Salary;

        // Getter and Setter for Salary with validation
        public decimal GetSalary()
        {
            return Salary;
        }
        public bool SetSalary(decimal salary)
        {
            if (salary < 0)
            {
                Console.WriteLine("\nSalary cannot be negative, Try again!");
                Logger.WriteLog("EMPLOYEE", $"Failed salary update for {Name} (ID={Id})");
                return false; //operation failed
            }

            Salary = salary;
            Logger.WriteLog("EMPLOYEE", $"Salary updated for {Name} (ID={Id}), NewSalary={Salary}");
            return true; //operation successful
        }

        // Constructor
        public Employee(int id, string name, Department department, decimal salary)
        {
            Id = id;
            Name = name;
            Department = department;
            SetSalary(salary);
        }
        // Virtual method for calculating pay, can be overridden by derived classes
        public virtual decimal CalculatePay(double hoursWorked)
        {
            if (hoursWorked < 0)
            {
                Console.WriteLine("\nHours worked cannot be negative!");
                Logger.WriteLog("PAYROLL", $"Failed to calculate pay for {Name} (ID={Id})");
                return 0;
            }

            double normalHours = 160; // Assuming 160 hours as standard monthly hours
            decimal hourlyRate = GetSalary() / (decimal)normalHours; 
            decimal pay = hourlyRate * (decimal)Math.Min(hoursWorked, normalHours);

            Logger.WriteLog("PAYROLL", $"Calculated base pay for {Name} (ID={Id}): {pay:C} for {hoursWorked} hours.");

            return pay;
        }
        // Method to request leave
        public LeaveRequest RequestLeave(int days, string reason)
        {
            LeaveRequest req = new LeaveRequest(Id, days, reason);
            Logger.WriteLog("LEAVE", $"Employee {Name} (ID={Id}) requested leave for {days} days. Reason: {reason}");
            return req;
        }
        // Override ToString for easy display
        public override string ToString()
        {
           return $"ID: {Id}, Name: {Name}, Department: {Department}, Salary: {Salary:C}\n";
        }
    }
}
