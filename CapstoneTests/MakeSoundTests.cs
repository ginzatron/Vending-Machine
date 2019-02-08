using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
namespace CapstoneTests
{
    [TestClass]
    public class MakeSoundTests
    {
        [TestMethod]
        public void GumMakesChewChewSound()
        {
            Gum gum = new Gum("A1", "Spearmint", (decimal)1.00, "Gum");
            string actualString = gum.MakeSound();
            Assert.AreEqual("Chew Chew, Yum!", actualString, "Gum items should make chew sound.");
        }

        [TestMethod]
        public void ChipMakesCrunchCrunchSound()
        {
            Chip chip = new Chip("A1", "Sun Chips", (decimal)1.00, "Chip");
            string actualString = chip.MakeSound();
            Assert.AreEqual("Crunch Crunch, Yum!", actualString, "Chip items should make chip sound.");

        }

        [TestMethod]
        public void DrinkMakesGlugGlugSound()
        {
            Drink drink = new Drink("A1", "Coke", (decimal)1.00, "Drink");
            string actualString = drink.MakeSound();
            Assert.AreEqual("Glug Glug, Yum!", actualString, "Drink items should make glug sound.");

        }

        [TestMethod]
        public void CandyMakesMunchMunchSound()
        {
            Candy candy = new Candy("A1", "Snickers", (decimal)1.00, "Candy");
            string actualString = candy.MakeSound();
            Assert.AreEqual("Munch Munch, Yum!", actualString, "Candy items should make munch sound.");

        }
    }
}
