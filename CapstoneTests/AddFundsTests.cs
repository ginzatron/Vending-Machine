using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class AddFundsTests
    {
        [TestMethod]
        public void StartWithZeroAddZeroEndWithZero()
        {
            VendingMachine vendingMachine = new VendingMachine();
            decimal returnedBalance = vendingMachine.AddFunds();
            Assert.AreEqual(0, returnedBalance, "Adding zero to zero balance keeps the balance at zero.");
        }
    }
}
