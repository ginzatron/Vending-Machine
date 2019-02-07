using System;

namespace Capstone.Classes
{
    /// <summary>
    /// Gum IS-A Item
    /// </summary>
    public class Gum : Item
    {
        public override void MakeSound()
        {
            Console.WriteLine("Chew Chew, Yum!");
        }
    }
}
