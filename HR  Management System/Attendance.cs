using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class Attendance
    {
        public int EmployeeID { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }

        public Logger logger ;
        public Attendance(Logger logger)
        {
            this.logger = logger;
        }

        public void CheckIn(int employeeId)
        {
            EmployeeID = employeeId;
            CheckInTime = DateTime.Now;
            logger.WriteLog($"Employee {EmployeeID} checked in at {CheckInTime}");
        }
        public void CheckOut()
        {
            CheckOutTime = DateTime.Now;
            logger.WriteLog($"Employee {EmployeeID} checked out at {CheckOutTime}");
        }

        public double GetTotalHours()
        {
            if (CheckOutTime < CheckInTime)
            {
                throw new Exception("Check-out time cannot be before check-in time!");
            }

            return (CheckOutTime - CheckInTime).TotalHours;
        }
    }
}
