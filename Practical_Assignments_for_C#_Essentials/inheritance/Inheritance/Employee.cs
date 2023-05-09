using System;

namespace InheritanceTask
{
    public class Employee
    {
        readonly private string name;
        private decimal salary;
        private decimal bonus;

        public Employee(string name, decimal salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public string Name
        {
            get { return name; }
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public virtual void SetBonus(decimal bonus)
        {
            this.bonus = bonus;
        }

        public decimal ToPay()
        {
            return salary + bonus;
        }
    }
}
