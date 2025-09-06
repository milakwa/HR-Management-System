using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class Intern : Employee
    {
        public Intern(int id, string name, string department, decimal salary) 
            : base(id, name, department, salary )
        {
        }

        public override decimal CalculatePay(double hoursWorked)
        {
            if (hoursWorked < 0)
            {
                Console.WriteLine("Hours worked cannot be negative!");
                Logger.WriteLog("PAYROLL", $"Failed to calculate pay for {Name} (ID={Id})");
                return 0;
            }

            decimal stipend = GetSalary();// Interns receive a fixed stipend

            Logger.WriteLog("PAYROLL",$"Intern {Name} (ID={Id}) received fixed stipend: {stipend:C}");

            return stipend; 
        }
    }
}
