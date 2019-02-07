using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

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
