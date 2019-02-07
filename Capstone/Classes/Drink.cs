using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Drink : Item
    {
        public override void MakeSound()
        {
            Console.WriteLine("Glug Glug, Yum!");
        }
    }
}
