using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class SpecialDeposit : Deposit, IProlongable
    {
        public SpecialDeposit(decimal amount, int period) : base(amount, period)
        {
        }

        public override decimal Income()
        {
            decimal sum = Amount;
            decimal interestRate = 0.01m;

            for (int i = 1; i <= Period; i++)
            {
                decimal interest = sum * interestRate;
                sum += interest;
            }

            decimal income = sum - Amount;
            return Math.Round(income, 3, MidpointRounding.AwayFromZero);
        }

        public bool CanToProlong()
        {
            return Amount > 1000;
        }
    }
}
