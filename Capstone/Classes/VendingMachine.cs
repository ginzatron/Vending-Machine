using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    /// <summary>
    /// creates vending machine
    /// </summary>
    public class VendingMachine
    {
        Dictionary<string, Item> stock = new Dictionary<string, Item>();
        ShoppingCart cart = new ShoppingCart();

        public decimal Balance { get; set; }

        /// <summary>
        /// contruct vending machine of item objects
        /// </summary>
        public VendingMachine()
        {
            this.Balance = 0.0M;

            using (StreamReader sr = new StreamReader("vendingmachine.csv"))
            {
                while (!sr.EndOfStream)
                {
                    //string array of all read in values
                    string[] items = sr.ReadLine().Split("|");
                    //create new item object with read in values (slot location, name, price, type)
                    Item item = new Item(items[0], items[1], decimal.Parse(items[2]), items[3]);
                    //assigning dictionary key as the slot and value as the itme object
                    stock[items[0]] = item;
                }
            }
        }

        /// <summary>
        /// Display Vending Machine items
        /// </summary>
        public void DisplayItems()
        {
            //loop through dictioary that uses the slot location as the key and the item object as the value
            foreach (KeyValuePair<string, Item> kvp in stock)
            {
                string key = kvp.Key;
                Item value = kvp.Value;

                string quantityDisplay = value.Quantity.ToString();
                if (value.Quantity == 0) quantityDisplay = "SOLD OUT";

                Console.WriteLine($"{value.SlotLocationn,-1} {value.Name,-20} Price {value.Price,-8:C2} {value.Type,-7} Available {quantityDisplay}");
            }
            Console.WriteLine();
        }

        public void UpdateQuantity()
        {

        }

        public decimal AddFunds()
        {
            List<int> nums = new List<int>() { 1, 2, 5, 10 };

            while (true)
            {
                Console.Write("Please Enter Dollar Amount 1,2,5 or 10 $");
                int enteredBills = int.Parse(Console.ReadLine());
                if (nums.Contains(enteredBills))
                {
                    Balance += enteredBills;
                }
                Console.Clear();
                return Balance;
            }
        }

        public decimal SelectProduct()
        {
            Console.Write("Please enter LetterNumber item slot to purchase from: ");
            string itemSlot = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (stock.ContainsKey(itemSlot) && stock[itemSlot].Price < Balance && stock[itemSlot].Quantity > 0)
            {
                Balance -= stock[itemSlot].Price;
                (stock[itemSlot].Quantity)--;
                cart.ItemsPurchased(stock[itemSlot]);
            }

            else if (stock[itemSlot].Price > Balance)
            {
                Console.WriteLine("PLEASE ADD MORE FUNDS!\n");
            }

            else if (stock[itemSlot].Quantity == 0)
            {
                Console.WriteLine("ITEM SOLD OUT!\n");
            }
            return Balance;
        }

        public void MakeChange()
        {
            Balance *= 100;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            Console.WriteLine($"Here is the remaining balance of {Balance/100}");

            while (Balance > 0)
            {
                if (Balance % 25 == 0 && Balance >= 25)
                {
                    quarters++;
                    Balance -= 25;
                }
                else if (Balance % 10 == 0 && Balance >= 10)
                {
                    dimes++;
                    Balance -= 10;
                }
                else if (Balance %5 == 0 && Balance >=5)
                {
                    nickels++;
                    Balance -= 5;
                }
            }
            Console.WriteLine($"{quarters} Quarter(s), {dimes} Dime(s), {nickels} nickel(s)");
            Console.WriteLine($"{Balance:C2} remaining");
            Console.WriteLine();

        }

    }
}
