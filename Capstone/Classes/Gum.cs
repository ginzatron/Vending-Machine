using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

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
