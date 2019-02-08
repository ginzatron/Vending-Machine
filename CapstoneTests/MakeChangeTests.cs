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
            Assert.AreEqual("0 Quarter(s), 0 Dime(s), 0 Nickel(s)", vendingMachine.MakeChangeMessage, "A balance of zero returns no change.");
            Assert.AreEqual(0, actualBalance, "A balance ends at zero.");
        }

        [TestMethod]
        public void OneDollarReturns4Qaurters()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = 1;
            decimal actualBalance = vendingMachine.MakeChange();
            Assert.AreEqual("4 Quarter(s), 0 Dime(s), 0 Nickel(s)", vendingMachine.MakeChangeMessage, "One dollar returns four quarters.");
            Assert.AreEqual(0, actualBalance, "After change is given balance returns to zero.");
        }

        [TestMethod]
        public void TwentyCentsReturnsTwoDimes()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = .20M;
            decimal actualBalance = vendingMachine.MakeChange();
            Assert.AreEqual("0 Quarter(s), 2 Dime(s), 0 Nickel(s)", vendingMachine.MakeChangeMessage, "Twenty cents returns two dimes.");
            Assert.AreEqual(0, actualBalance, "After change is given balance returns to zero.");
        }

        [TestMethod]
        public void FiveCentsReturnsOneNickel()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = .05M;
            decimal actualBalance = vendingMachine.MakeChange();
            Assert.AreEqual("0 Quarter(s), 0 Dime(s), 1 Nickel(s)", vendingMachine.MakeChangeMessage, "Five cents returns one Nickel.");
            Assert.AreEqual(0, actualBalance, "After change is given balance returns to zero.");
        }

        [TestMethod]
        public void OneSixtyFiveReturns4Qaurters1Dime1Nickel()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Balance = 1.65M;
            decimal actualBalance = vendingMachine.MakeChange();
            Assert.AreEqual("6 Quarter(s), 1 Dime(s), 1 Nickel(s)", vendingMachine.MakeChangeMessage, "Five cents returns one Nickel.");
            Assert.AreEqual(0, actualBalance, "After change is given balance returns to zero.");
        }



    }
}
