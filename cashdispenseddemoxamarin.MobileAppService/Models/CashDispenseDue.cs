using System;

namespace Models
{
    public class CashDispenseDue
    {
		public readonly static Cash DefaultAmountOwed = new Cash() { Denomination = "R", Number = "25.50" };

		public CashDispenseDue()
        {
            AmountOwed = DefaultAmountOwed;
        }

        public Cash AmountOwed
        {
            get;
            set;
        }
    }
}