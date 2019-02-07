using System;

namespace Capstone.Classes
{
    public class Gum : Item
    {
        public override void MakeSound()
        {
            Console.WriteLine("Chew Chew, Yum!");
        }
    }
}
