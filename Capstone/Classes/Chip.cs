using System;
using System.Collections.Generic;
using System.Text;

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
