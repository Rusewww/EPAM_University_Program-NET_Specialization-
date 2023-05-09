namespace Aggregation
{
    public abstract class Deposit
    {
        public decimal Amount { get; }
        public int Period { get; }

        public Deposit(decimal amount, int period)
        {
            Amount = amount;
            Period = period;
        }

        public abstract decimal Income();
    }
}
