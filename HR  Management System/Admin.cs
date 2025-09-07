using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
     public class Admin 
 {
     // Default admin credentials
     private string username = "Admin";
     private string password = "2244";
     // List to store employees
     public List<Employee> employees = new List<Employee>();

     // Admin login method
     public bool Login(string user, string pass)
     {
         // Case-insensitive username check
         if (user == username.ToLower() && pass == password)
         {
             Console.WriteLine("\nAdmin login successfully."); 
             Logger.WriteLog("ADMIN", "Login successful for Admin.");

             return true;
         }
         else
         {
             Console.WriteLine("\nInvalid admin credentials. Try again.\n");
             Logger.WriteLog("ADMIN", "Failed admin login attempt.");

             return false;
         }
     }
     // Method to add a new employee
     public bool AddEmployee(Employee emp)
     {
         // Check for null employee object
         if (emp == null)
         {
             Console.WriteLine("\nInvalid employee data. Try again.\n");
             Logger.WriteLog("ADMIN", "Failed to add employee (null object).");

             return false;
         }
         // Prevent adding duplicate employees based on ID
         foreach (Employee e in employees)
         {
             if (e.Id == emp.Id)
             {
                 Console.WriteLine($"\nEmployee with ID={emp.Id} already exists. Cannot add duplicate.");
                 Logger.WriteLog("ADMIN", $"Failed to add employee {emp.Name} (ID={emp.Id}) - already exists.");

                 return false;
             }
         }
         // Add employee to the list
         employees.Add(emp);
         string role = emp.GetType().Name;
         Console.WriteLine($"\n{role} {emp.Name} added successfully.");
         Logger.WriteLog("ADMIN", $"Added new {role}: {emp.Name} (ID={emp.Id}).");

         return true;
     }
     // Method to update an employee's salary
     public bool UpdateEmployeeSalary(Employee emp,decimal newSalary)
     {
         // Check for null employee object
         if (emp == null)
         {
             Console.WriteLine("\nInvalid employee data. Try again.\n");
             Logger.WriteLog("ADMIN", "Failed to update salary (null employee).");

             return false;
         }
         // Attempt to set the new salary
         if (emp.SetSalary(newSalary))
         {
             Console.WriteLine($"\n{emp.GetType().Name} {emp.Name}'s salary updated to {newSalary:C}.");
             Logger.WriteLog("ADMIN", $"Salary updated for {emp.Name} (ID={emp.Id}) to {newSalary}");

             return true;
         }
         // Salary update failed due to validation in SetSalary
         else
         {
             Console.WriteLine($"\nFailed to update salary for {emp.Name} (ID={emp.Id}). Try again...");
             Logger.WriteLog("ADMIN", $"Failed salary update for {emp.Name} (ID={emp.Id})");

             return false;
         }
        
     }
     // Method to retrieve an employee by ID
     public Employee GetEmployeeById(int empId)
     {
         // Search for the employee in the list
         foreach (Employee emp in employees)
         {
             if (emp.Id == empId)
             {
                 return emp;
             }

         }

         return null;

     }
     // Method to display an employee's details
     public bool GetEmployee(Employee emp)
     {
         // Check for null employee object
         if (emp == null)
         {
             Console.WriteLine("Employee not found.");
             return false;
         }
         // Display employee details
             Console.WriteLine(emp.ToString());
             return true;
         }
     // Method to display all employees
     public bool DisplayAllEmployees()
     {
         // Check if there are any employees in the list
         if (employees.Count == 0)
         {
             Console.WriteLine("No employees in the system.");
             return false;
         }
         // Display each employee's details
         foreach (Employee employee in employees)
         {
             Console.WriteLine(employee.ToString());
         }
         return true;
     }
     // Method to calculate payroll for an employee based on attendance records
     public decimal CalculatePayroll(Employee emp, List<Attendance> records)
     {
         // Validate employee object
         var completeRecords = records.Where(r => r.EmployeeID == emp.Id && r.CheckOutTime != default).ToList();

         if (completeRecords.Count==0)
         {
             Console.WriteLine("\nNo complete attendance records found. Cannot calculate payroll.");
             Logger.WriteLog("PAYROLL", $"Payroll calculation failed for {emp.Name} (ID={emp.Id}) - No complete attendance records.");
             return 0;
         }
         // Sum total hours from complete attendance records
         double totalHours = completeRecords.Sum(r => r.GetTotalHours());

         Payroll payroll = new Payroll();
         decimal totalPay = payroll.CalculateSalary(emp, totalHours);

         return totalPay;
     }
 }
}
