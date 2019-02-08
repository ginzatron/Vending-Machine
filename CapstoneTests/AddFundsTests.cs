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
            decimal returnedBalance = vendingMachine.AddFunds(0);
            Assert.AreEqual(0, returnedBalance, "Adding zero to zero balance keeps the balance at zero.");
        }

        [TestMethod]
        public void Adding1ChangesBalanceTo1()
        {
            VendingMachine vendingMachine = new VendingMachine();
            decimal returnedBalance = vendingMachine.AddFunds(1);
            Assert.AreEqual(1, returnedBalance, "Adding 1 dollar changes balance to 1.");
        }

        [TestMethod]
        public void Adding5ChangesBalanceTo5()
        {
            VendingMachine vendingMachine = new VendingMachine();
            decimal returnedBalance = vendingMachine.AddFunds(5);
            Assert.AreEqual(5, returnedBalance, "Adding 5 dollars changes balance to 5.");
        }

        [TestMethod]
        public void Adding10ChangesBalanceTo5()
        {
            VendingMachine vendingMachine = new VendingMachine();
            decimal returnedBalance = vendingMachine.AddFunds(10);
            Assert.AreEqual(10, returnedBalance, "Adding 10 dollars changes balance to 10.");
        }
    }
}
