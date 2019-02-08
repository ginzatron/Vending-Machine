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
            string actualMessage = vendingMachine.MakeChange();
            decimal actualBalance = vendingMachine.Balance;
            Assert.AreEqual("0 Quarter(s), 0 Dime(s), 0 Nickel(s)", actualMessage, "A balance of zero returns no change.");
            Assert.AreEqual(0, actualBalance, "A balance ends at zero.");
        }

        [TestMethod]
        public void OneDollarReturns4Qaurters()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = 1;
            string actualMessage = vendingMachine.MakeChange();
            decimal actualBalance = vendingMachine.Balance;
            Assert.AreEqual("4 Quarter(s), 0 Dime(s), 0 Nickel(s)", actualMessage, "One dollar returns four quarters.");
            Assert.AreEqual(0, actualBalance, "After change is given balance returns to zero.");
        }

        [TestMethod]
        public void TwentyCentsReturnsTwoDimes()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = .20M;
            string actualMessage = vendingMachine.MakeChange();
            decimal actualBalance = vendingMachine.Balance;
            Assert.AreEqual("0 Quarter(s), 2 Dime(s), 0 Nickel(s)", actualMessage, "Twenty cents returns two dimes.");
            Assert.AreEqual(0, actualBalance, "After change is given balance returns to zero.");
        }

        [TestMethod]
        public void FiveCentsReturnsOneNickel()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = .05M;
            string actualMessage = vendingMachine.MakeChange();
            decimal actualBalance = vendingMachine.Balance;
            Assert.AreEqual("0 Quarter(s), 0 Dime(s), 1 Nickel(s)", actualMessage, "Five cents returns one Nickel.");
            Assert.AreEqual(0, actualBalance, "After change is given balance returns to zero.");
        }

        [TestMethod]
        public void OneSixtyFiveReturns4Qaurters1Dime1Nickel()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = 1.65M;
            string actualMessage = vendingMachine.MakeChange();
            decimal actualBalance = vendingMachine.Balance;
            Assert.AreEqual("6 Quarter(s), 1 Dime(s), 1 Nickel(s)", actualMessage, "Five cents returns one Nickel.");
            Assert.AreEqual(0, actualBalance, "After change is given balance returns to zero.");
        }



    }
}
