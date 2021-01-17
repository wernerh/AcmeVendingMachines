using AcmeVendingMachines.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AcmeVendingMachines.UnitTests
{
    [TestClass]
    public class AcmeVendingMachinesUnitTest
    {
        [TestMethod]
        public void CalculateBritishPoundTestCase()
        {
            var coinDenominations = new int[6] { 1, 2, 5, 10, 20, 50 };
            var machine = new VendingMachine(coinDenominations);       
            var purchaseAmount = 1.35;
            var tenderAmount = 2.00; 
            var change = machine.CalculateChange(purchaseAmount, tenderAmount);

            Assert.AreEqual(65, change.Sum());
            Assert.AreEqual(50, change[0]);
            Assert.AreEqual(10, change[1]);
            Assert.AreEqual(5, change[2]);
        }

        [TestMethod]
        public void CalculateUSDollarTestCase()
        {
            var coinDenominations = new int[4] { 1, 5, 10, 25 };
            var machine = new VendingMachine(coinDenominations);
            var purchaseAmount = 1.35;
            var tenderAmount = 2.00;
            var change = machine.CalculateChange(purchaseAmount, tenderAmount);

            Assert.AreEqual(65, change.Sum());
            Assert.AreEqual(25, change[0]);
            Assert.AreEqual(25, change[1]);
            Assert.AreEqual(10, change[2]);
            Assert.AreEqual(5, change[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The tender amount is smaller than the purchase amount")]
        public void TenderAmountSmallerThanPurchaseAmountTestCase()
        {
            var coinDenominations = new int[4] { 1, 5, 10, 25 };
            var machine = new VendingMachine(coinDenominations);
            var purchaseAmount = 1.35;
            var tenderAmount = 1;
            var change = machine.CalculateChange(purchaseAmount, tenderAmount);
        }
    }
}
