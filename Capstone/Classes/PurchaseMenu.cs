using System;
using System.IO;

namespace Capstone.Classes
{
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
                    this.CreateLog(vendingMachine.Balance, vendingMachine.AddFunds(), "FEED MONEY");
                }
                else if (choice == "2")
                {
                    this.CreateLog(vendingMachine.Balance, vendingMachine.SelectProduct(), "Item");
                }
                else if (choice == "3")
                {
                    vendingMachine.MakeChange();
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
