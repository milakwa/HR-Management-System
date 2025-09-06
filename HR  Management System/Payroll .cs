using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class Payroll
    {
        public Logger logger;
        public Payroll(Logger logger)
        {
            this.logger = logger;
        }   
        public decimal CalculateSalary(Employee emp,double hoursWorked)
        {
            decimal totalPay = emp.CalculatePay(hoursWorked);
            logger.WriteLog($"Calculated salary for Employee [ID={emp.Id}, Name={emp.Name}]: {totalPay:C} for {hoursWorked} hours worked.");
            return totalPay;
            
        }
    }
}
