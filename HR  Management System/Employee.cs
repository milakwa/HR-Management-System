using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        private decimal Salary;

        public decimal GetSalary()
        {
            return Salary;
        }
        public bool SetSalary(decimal salary)
        {
            if (salary < 0)
            {
                Console.WriteLine("Salary cannot be negative!");
                Logger.WriteLog("EMPLOYEE", $"Failed salary update for {Name} (ID={Id})");
                return false; //operation failed
            }

            Salary = salary;
            Logger.WriteLog("EMPLOYEE", $"Salary updated for {Name} (ID={Id}), NewSalary={Salary}");
            return true; //operation successful
        }


        public Employee(int id, string name, string department, decimal salary)
        {
            Id = id;
            Name = name;
            Department = department;
            SetSalary(salary);
        }
        public virtual decimal CalculatePay(double hoursWorked)
        {
            if (hoursWorked < 0)
            {
                Console.WriteLine("Hours worked cannot be negative!");
                Logger.WriteLog("PAYROLL", $"Failed to calculate pay for {Name} (ID={Id})");
                return 0;
            }

            double normalHours = 160; // Assuming 160 hours as standard monthly hours
            decimal hourlyRate = GetSalary() / (decimal)normalHours; 
            decimal pay = hourlyRate * (decimal)Math.Min(hoursWorked, normalHours);

            Logger.WriteLog("PAYROLL", $"Calculated base pay for {Name} (ID={Id}): {pay:C} for {hoursWorked} hours.");

            return pay;
        }

        public override string ToString()
        {
           return$"ID: {Id}, Name: {Name}, Department: {Department}, Salary: {Salary:C}";
        }
    }
}
