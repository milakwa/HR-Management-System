namespace HR__Management_System
{
    
    internal class Program
    {
        public static List<Employee> employees = new List<Employee>();
        static void Main(string[] args)
        {
            Employee emp = new Employee(1, "John Doe", "IT", 80000);
            Manager manager = new Manager(2, "Jane Smith", "IT", 120000);

            Console.WriteLine(emp.ToString());
            Console.WriteLine(manager.ToString());
            Logger logger = new Logger();
            logger.LoadLogs();
            logger.DisplayLogs();
            Attendance attendance = new Attendance(logger);
            attendance.CheckIn(emp.Id);
            attendance.CheckOut();
            attendance.CheckIn(manager.Id);
            attendance.CheckOut();

            Payroll payroll = new Payroll(logger);
            Console.WriteLine(payroll.CalculateSalary(emp, attendance.GetTotalHours()));
            Console.WriteLine(payroll.CalculateSalary(manager, attendance.GetTotalHours()));
            

            logger.DisplayLogs();

           


        } 
    }
}
