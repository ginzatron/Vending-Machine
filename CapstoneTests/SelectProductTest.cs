using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class SelectProductTest
    {
        [TestMethod]
        public void SelectProductA1ChangesBalanceFrom10To695AndDecreasesItemQuantityFrom5To4()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = 10;
            decimal actualBalance = vendingMachine.SelectProduct("A1");
            Assert.AreEqual((decimal)6.95, actualBalance, "Selecting a1 should return a balance of 6.95.");
            Assert.AreEqual(4, vendingMachine.Stock["A1"].Quantity, "Selecting a1 should reduce quantity of the item from 5 to 4.");
        }
    }
}
