using AcmeVendingMachines.Core;
using System;
using System.Linq;

namespace AcmeVendingMachines
{
    class Program
    {
        static void Main(string[] args)
        {
            // coin denominations – British Dollar
            var coinDenominations = new int[6] { 1, 2, 5, 10, 20, 50 };

            // coin denominations – US Dollar
            //var coinDenominations = new int[4] { 1, 5, 10, 25 };

            var machine = new VendingMachine(coinDenominations);

            // amount the item cost
            var purchaseAmount = 1.35;

            // amount the user input for the purchase
            var tenderAmount = 2.00;

            // expect 65 cents
            var change = machine.CalculateChange(purchaseAmount, tenderAmount);

            Console.WriteLine($"Your change is : {change.Sum()}");  
            Console.ReadLine();
        }
    }
}
