using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR__Management_System
{
    public static class Logger
    {
        // In-memory log storage
        public static List<string> logs = new List<string>();  
        // Log file path
        public static string logFilePath = "system.log";
        // Method to write log entries
        public static void WriteLog(string module,string message)
        {
            // Format: [Timestamp] [Module] Message
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{module}] {message}";
            logs.Add(logEntry);
            // Also append to log file
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
        // Method to display logs
        public static void DisplayLogs()
        {
            // Display all logs in the console
            Console.WriteLine("\n--- System Logs ---");
            if(logs.Count == 0 )
            {
                Console.WriteLine("\nNo logs available.");

            }
            else
            {
                // Print each log entry
                foreach (var log in logs)
                {
                    Console.WriteLine(log);
                }
            }
            
        }
    }
}
