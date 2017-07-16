using System;
using System.Collections.Generic;

namespace cashdispenseddemoxamarin.Models
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

		public Cash OriginalCash
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