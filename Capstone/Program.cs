using System;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate fully stocked default vending machine
            VendingMachine vendingMachine = new VendingMachine();
            //instantiate a new instance of the main program menu to run from
            MainMenu mainMenu = new MainMenu();
            //pass staged vending machine to staged mainMenu
            mainMenu.Run(vendingMachine);
        }
    }
}