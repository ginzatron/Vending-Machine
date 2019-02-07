using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class MainMenu
    {
        public void Run(VendingMachine vendingMachine)
        {
            while (true)
            {
                Console.WriteLine("1. Display Vengind Machinee Items.");
                Console.WriteLine("2. Purchase Item(s)");
                Console.WriteLine("Q  Quit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    vendingMachine.DisplayItems();
                }
                else if (choice == "2")
                {
                    PurchaseMenu purchaseMenu = new PurchaseMenu();
                    purchaseMenu.Run(vendingMachine);
                }
                else if (choice.ToLower() == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid choice, please try again.");
                    Console.WriteLine();
                }
            }

        }
    }
}
