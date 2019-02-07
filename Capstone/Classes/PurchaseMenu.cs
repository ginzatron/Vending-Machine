using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

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
                Console.WriteLine("Q. Finish vending");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    vendingMachine.AddFunds();
                }
                else if (choice == "2")
                {

                }
                else if (choice.ToLower() == "q") break;
                else
                {
                    Console.WriteLine("Choice Not Valid");
                    Console.WriteLine("Please try again");
                    Console.WriteLine();
                }

            }

        }

    }
}
