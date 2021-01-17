using System.Collections.Generic;

namespace AcmeVendingMachines.Core
{
    public class VendingMachine
    {
        private int[] _CoinDenominations;

        public VendingMachine(int[] coinDenominations)
        {
            _CoinDenominations = coinDenominations;
        }

        public int[] CalculateChange(double purchaseAmount, double tenderAmount)
        {
            var result = new List<int>();

            return result.ToArray();
        }
    }
}
