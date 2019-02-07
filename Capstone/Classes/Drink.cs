using System;

namespace Capstone.Classes
{
    /// <summary>
    /// Drink IS-A Item
    /// </summary>
    public class Drink : Item
    {
        public override void MakeSound()
        {
            Console.WriteLine("Glug Glug, Yum!");
        }
    }
}
