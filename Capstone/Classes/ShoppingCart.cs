using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class ShoppingCart
    {
        List<Item> cart = new List<Item>();

        public void ItemsPurchased(Item item)
        {
            cart.Add(item);
        }
    }
}
