using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public class Logger
    {
        public List<string> logs = new List<string>();
        public string logFilePath = "system.log";
        public void WriteLog(string message)
        {
            string logEntry = $"{DateTime.Now}: {message}";
            logs.Add(logEntry);

            File.WriteAllLines(logFilePath, logs);
        }
        
        public void LoadLogs()
        {
            if (File.Exists(logFilePath))
            {
                logs = File.ReadAllLines(logFilePath).ToList();
            }
        }
        public void DisplayLogs()
        {
            Console.WriteLine("\n--- System Logs ---");
            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }
        }
    }
}
