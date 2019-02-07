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
            while (true)
            {
                Console.WriteLine("1. Add Funds");
                Console.WriteLine("2. Enter Product ID");
                Console.WriteLine("Q. Finish vending");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    //add funds to vending machine balance
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
