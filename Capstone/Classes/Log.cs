using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class Log
    {
        public void CreateLog(decimal totalBalance, decimal updatedBalance, string logAction)
        {
            string logMessage = $"{DateTime.Now.ToString("MM/dd/yyyy HH:mm")} {totalBalance} {updatedBalance} {logAction}";

            try
            {
                using (StreamWriter sw = new StreamWriter("Log.txt", true))
                {
                    sw.WriteLine($"{logMessage}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }

        }
    }
}
