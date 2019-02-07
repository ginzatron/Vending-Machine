using System;

namespace Capstone.Classes
{
    /// <summary>
    /// Drink IS-A Item
    /// </summary>
    public class Drink : Item
    {
        public Drink(string slotLocation, string name, decimal price, string type)
        : base(slotLocation, name, price, type)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Glug Glug, Yum!");
        }
    }
}
