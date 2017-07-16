﻿using System;
using System.Collections.Generic;

namespace cashdispenseddemoxamarin.MobileAppService.Models
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

        public string Summary
        {
            get
            {
                return string.Empty;
            }
        }
    }
}