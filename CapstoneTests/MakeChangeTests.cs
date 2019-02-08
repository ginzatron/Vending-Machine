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

        [TestMethod]
        public void OneDollarReturns4Qaurters()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = 1;
            decimal actualBalance = vendingMachine.MakeChange();
            Assert.AreEqual(4, vendingMachine.Quarters, "One dollar returns four quarters.");
        }

        [TestMethod]
        public void TwentyCentsReturnsTwoDimes()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = .20M;
            decimal actualBalance = vendingMachine.MakeChange();
            Assert.AreEqual(2, vendingMachine.Dimes, "Twenty cents returns two dimes.");
        }

        [TestMethod]
        public void FiveCentsReturnsOneNickel()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = .05M;
            decimal actualBalance = vendingMachine.MakeChange();
            Assert.AreEqual(1, vendingMachine.Nickels, "Five cents returns one Nickel.");
        }



    }
}
