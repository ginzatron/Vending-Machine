using System;

namespace Capstone.Classes
{
    public class Candy : Item
    {
        public override void MakeSound()
        {
            Console.WriteLine("Munch Munch, Yum!");
        }
    }
}
