using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone.Classes
{
    /// <summary>
    /// creates vending machine
    /// </summary>
    public class VendingMachine
    {
        private Dictionary<string, Item> stock = new Dictionary<string, Item>();
        private List<Item> cart = new List<Item>();

        public decimal Balance { get; private set; }

        /// <summary>
        /// Initializes new instance of VendingMachine.
        /// </summary>
        public VendingMachine()
        {
            this.Balance = 0.0M;

            using (StreamReader sr = new StreamReader("vendingmachine.csv"))
            {
                while (!sr.EndOfStream)
                {
                    // string array of all read in values
                    string[] items = sr.ReadLine().Split("|");

                    // create new item object with read in values (slot location, name, price, type)
                    // Item item = new Item(items[0], items[1], decimal.Parse(items[2]), items[3]);
                    if (items[3] == "Gum")
                    {
                        Item item = new Gum(items[0], items[1], decimal.Parse(items[2]), items[3]);
                        this.stock[items[0]] = item;
                    }
                    else if (items[3] == "Drink")
                    {
                        Item item = new Drink(items[0], items[1], decimal.Parse(items[2]), items[3]);
                        this.stock[items[0]] = item;
                    }
                    else if (items[3] == "Chip")
                    {
                        Item item = new Chip(items[0], items[1], decimal.Parse(items[2]), items[3]);
                        this.stock[items[0]] = item;
                    }
                    else if (items[3] == "Candy")
                    {
                        Item item = new Candy(items[0], items[1], decimal.Parse(items[2]), items[3]);
                        this.stock[items[0]] = item;
                    }
                }
            }
        }

        /// <summary>
        /// Display Vending Machine items
        /// </summary>
        public void DisplayItems()
        {
            // loop through dictioary that uses the slot location as the key and the item object as the value
            foreach (KeyValuePair<string, Item> kvp in this.stock)
            {
                string key = kvp.Key;
                Item value = kvp.Value;

                string quantityDisplay = value.Quantity.ToString();
                if (value.Quantity == 0)
                {
                    quantityDisplay = "SOLD OUT";
                }

                Console.WriteLine($"{value.SlotLocationn, -1} {value.Name, -20} Price {value.Price, -8:C2} {value.Type, -7} Available {quantityDisplay}");
            }

            Console.WriteLine();
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
                    this.Balance += enteredBills;
                }

                Console.Clear();
                return this.Balance;
            }
        }

        public decimal SelectProduct()
        {
            Console.Write("Please enter LetterNumber item slot to purchase from: ");
            string itemSlot = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (this.stock.ContainsKey(itemSlot) && this.stock[itemSlot].Price < this.Balance && this.stock[itemSlot].Quantity > 0)
            {
                this.Balance -= this.stock[itemSlot].Price;
                this.stock[itemSlot].Quantity--;

                Console.WriteLine($"{this.stock[itemSlot].Name} purchased");
                this.cart.Add(this.stock[itemSlot]);
            }
            else if (this.stock[itemSlot].Price > this.Balance)
            {
                Console.WriteLine("PLEASE ADD MORE FUNDS!\n");
            }
            else if (this.stock[itemSlot].Quantity == 0)
            {
                Console.WriteLine("ITEM SOLD OUT!\n");
            }
            else if (!this.stock.ContainsKey(itemSlot))
            {
                Console.WriteLine("Selection not valid");
            }

            return this.Balance;
        }

        public void MakeChange()
        {
            this.Balance *= 100;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            Console.WriteLine($"Here is the remaining balance of {this.Balance/100}");

            while (this.Balance > 0)
            {
                if (this.Balance % 25 == 0 && this.Balance >= 25)
                {
                    quarters++;
                    this.Balance -= 25;
                }
                else if (this.Balance % 10 == 0 && this.Balance >= 10)
                {
                    dimes++;
                    this.Balance -= 10;
                }
                else if (this.Balance %5 == 0 && this.Balance >=5)
                {
                    nickels++;
                    this.Balance -= 5;
                }
            }

            Console.WriteLine($"{quarters} Quarter(s), {dimes} Dime(s), {nickels} nickel(s)");
            Console.WriteLine($"{this.Balance:C2} remaining");
            Console.WriteLine();
            this.ConsumeItems();
        }

        public void ConsumeItems()
        {
            foreach (Item item in this.cart)
            {
                item.MakeSound();
            }
        }
    }
}
