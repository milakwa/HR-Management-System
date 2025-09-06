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
        public void SetSalary(decimal salary)
        {
            if (salary < 0)
            {
                Console.WriteLine("Salary cannot be negative.");
            }
            else
            {
                Salary = salary;
            }
        }

        public Employee(int id, string name, string department, decimal salary)
        {
            Id = id;
            Name = name;
            Department = department;
            Salary = salary;
        }
        public virtual decimal CalculatePay(double hoursWorked)
        {
            if (hoursWorked < 0)
            {
                throw new Exception("Hours worked cannot be negative!");
            }
            
            return Salary;
        }

        public override string ToString()
        {
           return$"ID: {Id}, Name: {Name}, Department: {Department}, Salary: {Salary:C}";
        }
    }
}
