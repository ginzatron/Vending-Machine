using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;


namespace CapstoneTests
{
    [TestClass]
    public class MakeChangeTests
    {
        [TestMethod]
        public void ZeroBalanceMakesZeroChange()
        {
            VendingMachine vendingMachine = new VendingMachine();
            decimal actualBalance = vendingMachine.MakeChange();
            Assert.AreEqual(0, actualBalance, "A balance of zero should return no change.");
        }

    }
}
