using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class BaseDeposit : Deposit
    {
        public BaseDeposit(decimal amount, int period) : base(amount, period)
        {
        }

        public override decimal Income()
        {
            decimal sum = Amount;
            decimal income = 0;

            for (int i = 1; i <= Period; i++)
            {
                decimal interest = Math.Round(sum * 0.05m, 2, MidpointRounding.AwayFromZero);
                income += interest;
                sum += interest;
            }

            return income;
        }
    }
}
