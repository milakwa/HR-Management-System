namespace HR__Management_System
{
    
     internal class Program
    {
        // Static lists to hold attendance records and leave requests
        public static List<Attendance> attendanceRecords = new List<Attendance>();
        // Static list to hold leave requests
        public static List<LeaveRequest> leaveRequests = new List<LeaveRequest>();
        static void Main(string[] args)
        {
            // Create an Admin instance
            Admin admin = new Admin();

            // Main menu loop
            int choice;
            do
            {
                Console.WriteLine("=== HR Management System ===");
                Console.WriteLine("1. Admin Portal");
                Console.WriteLine("2. Employee Portal");
                Console.WriteLine("3. Manager Portal");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("\nInvalid input. Try again.\n");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        AdminLogin(admin);// Prompt for admin login
                        AdminMenu(admin);// Show admin menu
                        break;
                    case 2:
                        EmployeeMenu(admin);// Show employee menu
                        break;
                    case 3:
                        ManagerMenu(admin);// Show manager menu
                        break;
                    case 4:
                        // Exit the application
                        Console.WriteLine("\nExiting...");
                        Logger.WriteLog("SYSTEM", "System exited safely.");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Try again.");
                        break;
                }

            } while (choice != 4);
        }
        // Admin login method
        public static void AdminLogin(Admin admin)
        {
            // Prompt for admin credentials
            Console.WriteLine("\n---Admin login---");

            bool loggedIn = false;
            while (!loggedIn)
            {
                Console.Write("Enter username: ");
                string user = Console.ReadLine().Trim().ToLower();
                Console.Write("Enter password: ");
                string pass = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
                {
                    Console.WriteLine("\nUsername and password cannot be empty. Try again.\n");
                    continue;
                }
                loggedIn = admin.Login(user, pass);
            }

        }
        // Admin menu method
        public static void AdminMenu(Admin admin)
        {
            // Admin menu loop
            int choice;
            do
            {
                Console.WriteLine("\n--- Admin Menu ---");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Update Employee Salary");
                Console.WriteLine("3. Display All Employees");
                Console.WriteLine("4. Calculate Payroll");
                Console.WriteLine("5. View Logs");
                Console.WriteLine("6. Exit to Main Menu");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("\nInvalid input. Please enter a number.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        // Add new employee
                        Console.WriteLine("\n---Enter Employee info---");
                        Employee employee = InputEmployeeDetails();
                        admin.AddEmployee(employee);
                        break;

                    case 2:
                        // Update employee salary
                        ChangeEmployeeSalary(admin);
                        break;

                    case 3:
                        // Display all employees
                        Console.WriteLine("\n---Employees Info----");
                        admin.DisplayAllEmployees();
                        break;

                    case 4:
                        //calculate payroll
                        CalculatePayroll(admin);
                        break;

                    case 5:
                        // View logs
                        Logger.DisplayLogs();
                        break;

                    case 6:
                        Console.WriteLine("\nReturning to main menu...\n");// return to main menu
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Try again.\n");
                        break;

                }
            } while (choice != 6);
        }
        // Method to input employee details
        public static Employee InputEmployeeDetails()
        {
            // Input employee details
            // Input ID
            Console.Write("Enter ID: ");
            int Id;
            while (!int.TryParse(Console.ReadLine(), out Id))
            {
                Console.WriteLine("\nInvalid ID. Try again.\n");
                Console.Write("Enter ID: ");
            }
            // Input name
            Console.Write("Enter Name: ");
            string name = Console.ReadLine().Trim().ToLower();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("\nName cannot be empty. Try again.\n");
                Console.Write("Enter Name: ");
                name = Console.ReadLine().Trim().ToLower();

            }
            // Select department
            Console.WriteLine("\n---Department available---");
            foreach (var dept in Enum.GetValues(typeof(Department)))
            {
                Console.WriteLine($"{(int)dept}. {dept}");
            }
            Console.Write("\nChoose Department:");
            int deptChoice;
            while (!int.TryParse(Console.ReadLine(), out deptChoice) || !Enum.IsDefined(typeof(Department), deptChoice))
            {

                Console.WriteLine("\nInvalid choice. Try again.");
                Console.Write("\nChoose Department:");

            }
            Department department = (Department)deptChoice;


            // Input salary
            Console.Write("Enter Salary: ");
            decimal salary;
            while (!decimal.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("\nInvalid salary.Try again.\n");
                Console.Write("Enter Salary: ");
            }

            // Select employee type
            Console.Write("Enter Type (1=Manager, 2=Developer, 3=Intern, 4=Employee): ");
            string type = Console.ReadLine();
            while (string.IsNullOrEmpty(type) || !(type == "1" || type == "2" || type == "3" || type == "4"))
            {
                Console.WriteLine("\nInvalid type. Try again.\n");
                Console.Write("Enter Type (1=Manager, 2=Developer, 3=Intern, 4=Employee): ");
            }
            Employee emp;
            switch (type)
            {
                case "1":
                    emp = new Manager(Id, name, department, salary);
                    break;
                case "2":
                    emp = new Developer(Id, name, department, salary);
                    break;
                case "3":
                    emp = new Intern(Id, name, department, salary);
                    break;
                default:
                    emp = new Employee(Id, name, department, salary);
                    break;
            }
            return emp;

        }
        // Method to change employee salary
        public static void ChangeEmployeeSalary(Admin admin)
        {
            while (true)
            {
                // Check if there are employees in the system
                if (admin.employees.Count == 0)
                {
                    Console.WriteLine("\nNo employees in the system. Add first.");
                    break;
                }

                Console.Write("\nEnter Employee ID to update salary: ");
                int empId;
                if (!int.TryParse(Console.ReadLine(), out empId))
                {
                    Console.WriteLine("\nInvalid ID. Try again.\n");
                    continue;
                }

                Employee emp = admin.GetEmployeeById(empId);
                if (emp == null)
                {
                    Console.WriteLine($"\nNo employee found with ID={empId}, Try again.\n");
                    continue;
                }
                // prompt for new salary
                Console.Write($"\nCurrent Salary of {emp.Name} is {emp.GetSalary():C}. Enter new Salary: ");
                decimal newSalary;
                if (!decimal.TryParse(Console.ReadLine(), out newSalary))
                {
                    Console.WriteLine("\nInvalid salary. Try again.\n");
                    continue;
                }
                // update salary
                if (!admin.UpdateEmployeeSalary(emp, newSalary))
                {
                    continue;
                }
                else
                {
                    break;
                }

            }

        }
        // Method to calculate payroll
        public static void CalculatePayroll(Admin admin)
        {

            while (true)
            {
                
                Console.Write("\nEnter Employee ID to calculate payroll: ");
                int empId;
                if (!int.TryParse(Console.ReadLine(), out empId))
                {
                    Console.WriteLine("\nInvalid ID. Try again.\n");
                    continue;
                }
                // get employee by ID
                Employee emp = admin.GetEmployeeById(empId);

                if (emp == null)
                {
                    Console.WriteLine($"\nNo employee found with ID={empId}, Try again.\n");
                    continue;
                }
                // calculate total pay
                decimal totalPay = admin.CalculatePayroll(emp, attendanceRecords);

                if (totalPay == 0)
                {
                    Console.WriteLine("\nPayroll calculation failed. Try again.");
                    continue;
                }
                else
                {
                    Console.WriteLine($"\nTotal pay for {emp.Name} (ID={emp.Id}) is {totalPay:C}");
                    break;
                }
            }

        }
        // Employee menu method
        public static void EmployeeMenu(Admin admin)
        {
            while (true)
            {
                // Check if there are employees in the system
                if (admin.employees.Count == 0)
                {
                    Console.WriteLine("\nNo employees in the system. Contact Admin.\n");
                    break;
                }
                Console.Write("\nEnter your Employee ID: ");
                if (!int.TryParse(Console.ReadLine(), out int empId))
                {
                    Console.WriteLine("\nInvalid ID.Try again.\n");
                    continue;
                }
                // get employee by ID
                Employee emp = admin.GetEmployeeById(empId);
                if (emp == null)
                {
                    Console.WriteLine("\nEmployee not found. Try again.\n");
                    continue;
                }
                // Show employee menu
                int choice;
                do
                {
                    Console.WriteLine($"\n--- Employee Menu ---");
                    Console.WriteLine("1. Check In");
                    Console.WriteLine("2. Check Out");
                    Console.WriteLine("3. Request Leave");
                    Console.WriteLine("4. Back to Main Menu");
                    Console.Write("Choose an option: ");

                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("\nInvalid input..Try again.\n");
                        continue;
                    }
                    switch (choice)
                    {
                        case 1:
                            Attendance.CheckIn(empId,attendanceRecords);//check in 
                            break;
                        case 2:
                            Attendance.CheckOut(empId,attendanceRecords);//check out
                            break;
                        case 3:
                            RequestLeaveData(emp,empId);// request leave
                            break;
                        case 4:
                            Console.WriteLine("\nReturning to main menu...\n");// return to main menu
                            break;
                        default:
                            Console.WriteLine("\nInvalid choice. Try again.\n");
                            break;
                    }
                } while (choice != 4);// exit to main menu
                break;
            }

        }
        // Method to request leave data
        public static void RequestLeaveData(Employee emp,int empId)
        {
            while (true)
            {
                //leave request data
                Console.WriteLine("\n---Leave request data---");
                Console.Write("Enter number of leave days: ");
                int days;
                if (!int.TryParse(Console.ReadLine(), out days) || days <= 0)
                {
                    Console.WriteLine("\nInvalid number of days. Try again.");
                    continue;
                }
                //check reason validity
                Console.Write("Enter reason: ");
                string reason = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(reason))
                {
                    Console.WriteLine("\nReason cannot be empty. Try again.");
                    continue;
                }
                if(reason.Any(char.IsWhiteSpace)|| reason.Any(char.IsLetter) || reason.Any(char.IsDigit))
                {
                    Console.WriteLine("\nReason cannot contain special characters or numbers. Try again.");
                    continue;
                }
                //create and add leave request
                LeaveRequest req = emp.RequestLeave(days, reason);
                leaveRequests.Add(req);
                Console.WriteLine("\nLeave request submitted.");
                break;

            }
        }
        // Manager menu method
        public static void ManagerMenu(Admin admin)
        {
            
            while (true)
            {
                
                if (admin.employees.Count == 0)
                {
                    Console.WriteLine("\nNo employees in the system. Contact Admin.\n");
                    break;
                }
                Console.Write("\nEnter your Employee ID: ");
                if (!int.TryParse(Console.ReadLine(), out int empId))
                {
                    Console.WriteLine("\nInvalid ID.Try again.\n");
                    continue;
                }
                // Check if the employee is a manager
                Employee emp = admin.GetEmployeeById(empId);
                if (emp == null || !(emp is Manager))
                {
                    Console.WriteLine("\nManager not found. Try again.\n");
                    continue;
                }
                //show manager menu
                int choice;
                do
                {
                    Console.WriteLine($"\n--- Manager Menu ---");
                    Console.WriteLine("1. Review Leave Requests");
                    Console.WriteLine("2. Back to Main Menu");
                    Console.Write("Choose an option: ");
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("\nInvalid input. Try again.\n");
                        continue;
                    }
                    switch (choice)
                    {
                        case 1:
                           ((Manager)emp).ReviewLeaveRequests(leaveRequests);//review leave requests
                            break;
                        case 2:
                            Console.WriteLine("\nReturning to main menu...\n");//return to main menu
                            break;
                        default:
                            Console.WriteLine("\nInvalid choice. Try again.\n");
                            break;
                    }
                } while (choice != 2);
                break;
            }
        }

    }
}
