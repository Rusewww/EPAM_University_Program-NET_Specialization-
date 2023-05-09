namespace Aggregation
{
    public class LongDeposit : Deposit
    {
        public LongDeposit(decimal amount, int period) : base(amount, period)
        {
        }

        public override decimal Income()
        {
            decimal sum = Amount;
            decimal income = 0;

            for (int i = 1; i <= Period; i++)
            {
                if (i <= 6)
                {
                    continue;
                }

                income += sum * 0.15m;
                sum += income;
            }

            return income;
        }
    }
}
