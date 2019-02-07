using System;

namespace Capstone.Classes
{
    /// <summary>
    /// Chip IS-A Item
    /// </summary>
    public class Chip : Item
    {
        public Chip(string slotLocation, string name, decimal price, string type)
        : base(slotLocation, name, price, type)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Crunch Crunch, Yum!");
        }
    }
}
