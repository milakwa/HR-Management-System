using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public static class Logger
    {
        public static List<string> logs = new List<string>();  
        public static string logFilePath = "system.log";
        public static void WriteLog(string module,string message)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{module}] {message}";
            logs.Add(logEntry);

            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
        
        public static void LoadLogs()
        {
            if (File.Exists(logFilePath))
            {
                logs = File.ReadAllLines(logFilePath).ToList();
            }
        }
        public static void DisplayLogs()
        {
            Console.WriteLine("\n--- System Logs ---");
            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }
        }
    }
}
