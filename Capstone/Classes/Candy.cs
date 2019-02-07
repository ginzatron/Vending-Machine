using System;

namespace Capstone.Classes
{
    /// <summary>
    /// Candy Is-A Item
    /// </summary>
    public class Candy : Item
    {
        public override void MakeSound()
        {
            Console.WriteLine("Munch Munch, Yum!");
        }
    }
}
