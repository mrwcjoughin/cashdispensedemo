using System;
using System.Collections.Generic;

namespace cashdispensedemobackend.Models
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