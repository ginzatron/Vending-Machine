using System;

namespace Capstone.Classes
{
    public class Chip : Item
    {
        public override void MakeSound()
        {
            Console.WriteLine("Crunch Crunch, Yum!");
        }
    }
}
