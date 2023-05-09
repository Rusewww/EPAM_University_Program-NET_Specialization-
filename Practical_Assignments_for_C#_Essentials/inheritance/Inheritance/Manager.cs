using System;
using System.Collections.Generic;
using System.Text;


namespace InheritanceTask
{
    public class Manager : Employee
    {
        readonly private int quantity;

        public Manager(string name, decimal salary, int clientAmount) : base(name, salary)
        {
            this.quantity = clientAmount;
        }

        public override void SetBonus(decimal bonus)
        {
            if (quantity > 150)
            {
                bonus += 1000;
            }
            else if (quantity > 100)
            {
                bonus += 500;
            }

            base.SetBonus(bonus);
        }
    }
}

