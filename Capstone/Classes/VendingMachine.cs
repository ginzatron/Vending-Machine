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
        public Dictionary<string, Item> Stock = new Dictionary<string, Item>();
        public Dictionary<string, int> TotalSales = new Dictionary<string, int>();
        public List<Item> Cart = new List<Item>();

        public decimal Balance { get; set; }

        public string LoggingInfo { get; set; }

        public decimal SalesOutput { get; set; }

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
                        this.Stock[items[0]] = item;
                    }
                    else if (items[3] == "Drink")
                    {
                        Item item = new Drink(items[0], items[1], decimal.Parse(items[2]), items[3]);
                        this.Stock[items[0]] = item;
                    }
                    else if (items[3] == "Chip")
                    {
                        Item item = new Chip(items[0], items[1], decimal.Parse(items[2]), items[3]);
                        this.Stock[items[0]] = item;
                    }
                    else if (items[3] == "Candy")
                    {
                        Item item = new Candy(items[0], items[1], decimal.Parse(items[2]), items[3]);
                        this.Stock[items[0]] = item;
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
            foreach (KeyValuePair<string, Item> kvp in this.Stock)
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

        public decimal AddFunds(int bill)
        {
             this.Balance += bill;

             return this.Balance;
        }

        public decimal SelectProduct(string itemSlot)
        {
            string name = this.Stock[itemSlot].Name;

            this.Balance -= this.Stock[itemSlot].Price;
            this.Stock[itemSlot].Quantity--;

            this.Cart.Add(this.Stock[itemSlot]);

            this.LoggingInfo = $"{itemSlot} {this.Stock[itemSlot].Name}";

            // populating total sales dictionary with item name as key and number purchased as value
            if (!this.TotalSales.ContainsKey(name))
            {
                this.TotalSales[name] = 1;
                this.SalesOutput += this.Stock[itemSlot].Price;
            }
            else
            {
                this.TotalSales[name] += 1;
                this.SalesOutput += this.Stock[itemSlot].Price;
            }

            return this.Balance;
        }

        public void TotalSalesReport()
        {
            string itemTotals = string.Empty;

            using (StreamWriter sr = new StreamWriter("salesReport.txt"))
            {
                foreach (KeyValuePair<string, int> item in this.TotalSales)
                {
                    sr.WriteLine($"{item.Key}|{item.Value}");
                }

                sr.WriteLine($"**Total Sales** {this.SalesOutput:C2}");
            }
        }

        public string MakeChange()
        {
            this.Balance *= 100;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            string changeMessage = string.Empty;

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
                else if (this.Balance % 5 == 0 && this.Balance >= 5)
                {
                    nickels++;
                    this.Balance -= 5;
                }
            }

            return changeMessage = $"{quarters} Quarter(s), {dimes} Dime(s), {nickels} Nickel(s)";
        }

        public string ConsumeItems()
        {
            string allItemsConsumed = string.Empty;

            foreach (Item item in this.Cart)
            {
                allItemsConsumed += item.MakeSound() + "\n";
            }

            Console.WriteLine();
            return allItemsConsumed;
        }
    }
}
