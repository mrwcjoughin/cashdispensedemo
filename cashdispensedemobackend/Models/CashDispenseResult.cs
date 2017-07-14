using System;
using System.Collections.Generic;

namespace testaspdotnetcore.Models
{
    public class CashDispenseResult
    {
        public CashDispenseResult()
        {
            ChangeResults = new List<Cash>();
        }

        public List<Cash> ChangeResults
        {
            get;
            set;
        }
    }
}