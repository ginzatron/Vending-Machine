using System;

namespace Capstone.Classes
{
    /// <summary>
    /// Chip IS-A Item
    /// </summary>
    public class Chip : Item
    {
        public override void MakeSound()
        {
            Console.WriteLine("Crunch Crunch, Yum!");
        }
    }
}
