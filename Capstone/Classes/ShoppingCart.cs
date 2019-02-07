using System;
using System.Collections.Generic;

namespace Capstone.Classes
{
    /// <summary>
    /// Instantiates cart to hold all items to be withdrawn
    /// </summary>
    public class ShoppingCart
    {
        private List<Item> cart = new List<Item>();

        public void ItemsPurchased(Item item)
        {
            Console.WriteLine($"{item.Name} purchased");
            this.cart.Add(item);
        }


    }
}
