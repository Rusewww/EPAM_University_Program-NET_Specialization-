using System;

namespace Interfaces
{
    public abstract class Deposit : IComparable<Deposit>
    {
        protected decimal _amount;
        protected int _period;

        public Deposit(decimal amount, int period)
        {
            _amount = amount;
            _period = period;
        }

        public decimal Amount
        {
            get { return _amount; }
        }

        public int Period
        {
            get { return _period; }
        }

        public abstract decimal Income();

        public decimal Total()
        {
            return _amount + Income();
        }

        public int CompareTo(Deposit other)
        {
            if (other == null)
                return 1;
            else
                return Total().CompareTo(other.Total());
        }

        public override string ToString()
        {
            return $"Amount: {Amount:C}, Income: {Income():C}, Total: {Total():C}";
        }

        //TODO: Implement interface "Iprolongable" and method "CanToProlong" in derived classes.
    }
}

