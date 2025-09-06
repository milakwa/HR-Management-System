using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{

    public class Admin 
    {
        private string username = "Admin";
        private string password = "2244";

        public bool Login(string user, string pass)
        {
            return (user == username && pass == password);
        }
        public void AddEmployee(Employee emp)
        {
            Program.employees.Add(emp);
            Console.WriteLine($"Employee {emp.Name} added successfully.");
        }
        public void UpdateEmployeeSalary(Employee emp,decimal newSalary)
        {
            emp.SetSalary(newSalary);
            Console.WriteLine($"Employee {emp.Name}'s salary updated to {newSalary:C}.");
        }
        public void GetEmployee(Employee emp)
        {
            emp.ToString();
        }
        public void DisplayAllEmployees()
        {
            foreach (Employee employee in Program.employees)
            {
                employee.ToString();
            }
        }
    }
}
