﻿using System;

namespace Capstone.Classes
{
    /// <summary>
    /// Gum IS-A Item
    /// </summary>
    public class Gum : Item
    {
        public Gum(string slotLocation, string name, decimal price, string type)
            : base(slotLocation, name, price, type)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Chew Chew, Yum!");
        }
    }
}
