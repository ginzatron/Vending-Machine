using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// instantiates new object for each item in list of items
    /// </summary>
    public class Item
    {
        public string Name { get; }
        public decimal Price { get;}
        public int Quantity { get; set; }
        public string SlotLocationn { get; }
        public string Type { get; }

        public Item()
        {

        }

        /// <summary>
        /// constructor using parameters read in from file in vendig machine class
        /// </summary>
        /// <param name="slotLocation"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="type"></param>
        public Item(string slotLocation, string name, decimal price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = 5;
            this.SlotLocationn = slotLocation;
            this.Type = type;
        }

        public virtual void MakeSound()
        {
            //make specified item sound on consumption
        }
    }
}
