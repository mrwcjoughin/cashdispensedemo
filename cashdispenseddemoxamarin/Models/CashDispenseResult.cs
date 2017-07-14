using System;
using System.Collections.Generic;

namespace cashdispenseddemoxamarin.Models
{
    public class CashDispenseResult
    {
        public CashDispenseResult()
        {
            ChangeResults = new List<Cash>();
        }

		public string Id
		{
			get;
			set;
		}

		public Cash OriginalCash
		{
			get;
			set;
		}

        public List<Cash> ChangeResults
        {
            get;
            set;
        }
    }
}