using System;
using System.Collections.Generic;
using System.Linq;

namespace Interfaces
{
    public class Client : IEnumerable<Deposit>
    {
        readonly private Deposit[] deposits;

        public Client()
        {
            deposits = new Deposit[10];
        }

        public bool AddDeposit(Deposit deposit)
        {
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] == null)
                {
                    deposits[i] = deposit;
                    return true;
                }
            }

            return false;
        }

        public decimal TotalIncome()
        {
            decimal totalIncome = 0;

            foreach (Deposit deposit in deposits)
            {
                if (deposit != null)
                {
                    totalIncome += deposit.Income();
                }
            }

            return totalIncome;
        }

        public decimal MaxIncome()
        {
            decimal maxIncome = 0;

            foreach (Deposit deposit in deposits)
            {
                if (deposit != null && deposit.Income() > maxIncome)
                {
                    maxIncome = deposit.Income();
                }
            }

            return maxIncome;
        }

        public decimal GetIncomeByNumber(int number)
        {
            if (number < 1 || number > deposits.Length || deposits[number - 1] == null)
            {
                return 0;
            }

            return deposits[number - 1].Income();
        }

        public void SortDeposits()
        {
            Array.Sort(deposits, (d1, d2) =>
            {
                if (d1 == null && d2 == null)
                    return 0;
                else if (d1 == null)
                    return 1;
                else if (d2 == null)
                    return -1;
                else
                    return -d1.Total().CompareTo(d2.Total());
            });
        }

        public int CountPossibleToProlongDeposit()
        {
            int count = 0;
            foreach (Deposit deposit in deposits)
            {
                if (deposit is IProlongable prolongableDeposit && prolongableDeposit.CanToProlong())
                {
                    count++;
                }
            }

            return count;
        }

        public IEnumerator<Deposit> GetEnumerator()
        {
            return ((IEnumerable<Deposit>)deposits).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return deposits.GetEnumerator();
        }
    }
}
