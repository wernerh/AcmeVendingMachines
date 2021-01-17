using System;
using System.Collections.Generic;

namespace AcmeVendingMachines.Core
{
    public class VendingMachine
    {
        private int[] _CoinDenominations;

        public VendingMachine(int[] coinDenominations)
        {
            _CoinDenominations = coinDenominations;
            // Sort coin denominations in descending order
            Array.Sort(_CoinDenominations, (a, b) => b.CompareTo(a));
        }

        public int[] CalculateChange(double purchaseAmount, double tenderAmount)
        {
            var result = new List<int>();
            if (purchaseAmount < 0 || tenderAmount < 0)
            {
                throw new ArgumentException("Invalid transaction");
            }

            // Convert tender amount to same unit as coin denominations
            var purchaseAmountConvertedToCents = purchaseAmount * 100;
            var tenderAmountConvertedToCents = tenderAmount * 100;

            // Calculate the change
            var change = tenderAmountConvertedToCents - purchaseAmountConvertedToCents;
            if (change < 0)
            {
                throw new ArgumentException("The tender amount is smaller than the purchase amount");
            }

            int index = 0;
            while (index < _CoinDenominations.Length)
            {
                if (change - _CoinDenominations[index] >= 0)
                {
                    result.Add(_CoinDenominations[index]);
                    change = change - _CoinDenominations[index];

                    if (change == 0)
                    {
                        break;
                    }
                }
                else
                {
                    index++;
                }
            }

            //Apply rounding if change is still outstanding
            if (change > 0 && change < _CoinDenominations[_CoinDenominations.Length - 1])
            {
                result.Add(_CoinDenominations[_CoinDenominations.Length - 1]);
            }

            return result.ToArray();
        }
    }
}
