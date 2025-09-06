using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class Intern : Employee
    {
        public Intern(int id, string name, string department, decimal salary) : base(id, name, department, salary)
        {
        }

        public override decimal CalculatePay(double hoursWorked)
        {
            if (hoursWorked < 0)
            {
                throw new Exception("Hours worked cannot be negative!");
            }

            return GetSalary(); // Interns are paid a fixed stipend
        }
    }
}
