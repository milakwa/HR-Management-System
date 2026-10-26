# HR Management System

## Overview
The HR Management System is a console-based application developed in C# as an individual summer training project. It manages basic human resources operations, including employee information, attendance, payroll calculations, and leave requests.

## Features

- **Employee Management:** Add employees, search by employee ID, display employee records, and update salaries.
- **Attendance Management:** Record employee check-in and check-out times and calculate working hours.
- **Payroll Calculation:** Calculate pay according to employee type, including overtime pay for Developers.
- **Leave Management:** Allow employees to submit leave requests and Managers to approve or reject them.
- **Input Validation:** Validate user input and handle invalid entries.
- **Activity Logging:** Record system activities and errors in a log file.

## Technologies Used

- C#
- .NET
- Object-Oriented Programming (OOP)
- Encapsulation, Inheritance, and Polymorphism
- Collections and LINQ
- File Handling

## User Roles

- **Admin:** Manages employee records, updates salaries, calculates payroll, and views system logs.
- **Employee:** Records attendance and submits leave requests.
- **Manager:** Reviews leave requests and approves or rejects them.

## Project Structure

The application is organized into classes, each responsible for a specific part of the system:

- `Employee`: Stores employee information and provides basic payroll and leave-request functionality.
- `Manager`: Handles manager-specific payroll and leave approval operations.
- `Developer`: Implements payroll calculations with overtime.
- `Intern`: Implements fixed-stipend payroll calculation.
- `Department`: Defines the available departments.
- `Attendance`: Handles check-in, check-out, and working-hour calculations.
- `LeaveRequest`: Represents a leave request and its status.
- `Payroll`: Handles salary calculation.
- `Admin`: Manages employees and coordinates payroll operations.
- `Logger`: Records system activities in a log file.
- `Program`: Provides the main menu and user interaction.

## How to Run

1. Install Visual Studio and a .NET SDK compatible with the project.
2. Clone or download this repository.
3. Open the solution (`.sln`) or project (`.csproj`) file in Visual Studio.
4. Restore any required dependencies if prompted.
5. Set the project as the startup project.
6. Build and run the application.
7. Follow the instructions displayed in the console menu.

## Testing

The application was run, and its main features were tested manually, including employee management, attendance, payroll calculations, and leave-request handling.

## Limitations

- The application uses a console-based interface.
- Employee records and leave requests are stored in memory during execution.
- System logs are written to a local file.
- The project is intended for educational and training purposes and is not presented as a production-ready HR system.

## Author

Individual Summer Training Project

## Repository

[HR Management System on GitHub](https://github.com/milakwa/HR-Management-System)
