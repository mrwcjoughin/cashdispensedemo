using System;
using System.Collections.Generic;

namespace Models
{
    public class CashDispenseResult
    {
        public CashDispenseResult()
        {
            ChangeResults = new List<ChangeResult>();
        }

        public string Id
        {
            get;
            set;
        }

        public CashDispenseDue CashDispenseDue
        {
            get;
            set;
        }

		public Cash CashHandedOver
		{
			get;
			set;
		}

		public List<ChangeResult> ChangeResults
		{
			get;
			set;
		}
    }
}