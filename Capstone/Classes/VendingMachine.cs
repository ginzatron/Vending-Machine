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

                Console.WriteLine($"{value.SlotLocationn} {value.Name} Price {value.Price:C2} {value.Type} Available {value.Quantity}");
            }
            Console.WriteLine();
        }

        public void UpdateQuantity()
        {

        }

        public void AddFunds()
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
                break;
            }
            Console.Clear();
        }

        public void SelectProduct()
        {
            Console.WriteLine("Please enter LetterNumber item slot to purchase from");
            string itemSlot = Console.ReadLine().ToUpper();

            if (stock.ContainsKey(itemSlot))
            {
                cart.ItemsPurchased(stock[itemSlot])
            }
        }
    }
}
