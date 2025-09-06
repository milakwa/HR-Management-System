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

        private List<Employee> employees = new List<Employee>();
        public bool Login(string user, string pass)
        {
            if(user == username && pass == password)
            {
                Console.WriteLine("Admin login successfully."); 
                Logger.WriteLog("ADMIN", "Login successful for Admin.");

                return true;
            }
            else
            {
                Console.WriteLine("Invalid admin credentials.");
                Logger.WriteLog("ADMIN", "Failed admin login attempt.");

                return false;
            }
        }
        public bool AddEmployee(Employee emp)
        {
            if (emp == null)
            {
                Console.WriteLine("Invalid employee data. Try again...");
                Logger.WriteLog("ADMIN", "Failed to add employee (null object).");

                return false;
            }

            foreach (Employee e in employees)
            {
                if (e.Id == emp.Id)
                {
                    Console.WriteLine($"Employee with ID={emp.Id} already exists. Cannot add duplicate.");
                    Logger.WriteLog("ADMIN", $"Failed to add employee {emp.Name} (ID={emp.Id}) - already exists.");

                    return false;
                }
            }
            
            employees.Add(emp);
            Console.WriteLine($"Employee {emp.Name} added successfully.");
            Logger.WriteLog("ADMIN", $"Employee {emp.Name} (ID={emp.Id}) added.");

            return true;
        }
        public bool UpdateEmployeeSalary(Employee emp,decimal newSalary)
        {
            if (emp == null)
            {
                Console.WriteLine("Invalid employee data. Try again...");
                Logger.WriteLog("ADMIN", "Failed to update salary (null employee).");

                return false;
            }

            if (emp.SetSalary(newSalary))
            {
                Console.WriteLine($"Employee {emp.Name}'s salary updated to {newSalary:C}.");
                Logger.WriteLog("ADMIN", $"Salary updated for {emp.Name} (ID={emp.Id}) to {newSalary}");

                return true;
            }
            else
            {
                Console.WriteLine($"Failed to update salary for {emp.Name} (ID={emp.Id}). Try again...");
                Logger.WriteLog("ADMIN", $"Failed salary update for {emp.Name} (ID={emp.Id})");

                return false;
            }
           
        }
        public bool GetEmployee(Employee emp)
        {
            if (emp == null)
            {
                Console.WriteLine("❌ Employee not found.");
                return false;
            }
            else
            {
                Console.WriteLine(emp.ToString());
                return true;
            }

        }
        public bool DisplayAllEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees in the system.");
                return false;
            }

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
            return true;
        }
    }
}
