using System;
using System.IO;

namespace Capstone.Classes
{
    /// <summary>
    /// Instantiates purchase menu
    /// </summary>
    public class PurchaseMenu
    {
        public void Run(VendingMachine vendingMachine)
        {
            Console.Clear();
            while (true)
            {
                vendingMachine.DisplayItems();
                Console.WriteLine($"1. Add Funds Balance: ${vendingMachine.Balance}");
                Console.WriteLine("2. Enter Product ID");
                Console.WriteLine("3. Finish vending");
                Console.WriteLine("Q  Quit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    // both logs the activity to add funds and add funds to the balance
                    this.CreateLog(vendingMachine.Balance, vendingMachine.AddFunds(), "FEED MONEY");
                }
                else if (choice == "2")
                {
                    // logs product ID choice
                    this.CreateLog(vendingMachine.Balance, vendingMachine.SelectProduct(), vendingMachine.LoggingInfo);
                }
                else if (choice == "3")
                {
                    // makes change on remaining balance
                    this.CreateLog(vendingMachine.Balance, vendingMachine.MakeChange(), "GIVE CHANGE");
                }
                else if (choice.ToLower() == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Choice Not Valid");
                    Console.WriteLine("Please try again");
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Creates log file for each transaction (feeding money, withdrawing Item)
        /// </summary>
        /// <param name="totalBalance">machine balance</param>
        /// <param name="updatedBalance">new balance</param>
        /// <param name="logAction">log activity</param>
        public void CreateLog(decimal totalBalance, decimal updatedBalance, string logAction)
        {
            string logMessage = $"{DateTime.Now.ToString("MM/dd/yyyy HH:mm")} ${totalBalance, -6} ${updatedBalance, -6} {logAction, 1}";

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
