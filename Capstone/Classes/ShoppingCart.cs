using System;
using System.Collections.Generic;

namespace Capstone.Classes
{
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
