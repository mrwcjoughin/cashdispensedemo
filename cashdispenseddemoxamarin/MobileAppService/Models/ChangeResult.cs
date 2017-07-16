using System;

namespace cashdispenseddemoxamarin.MobileAppService.Models
{
    public class ChangeResult
    {
        public ChangeResult()
        {
        }

		public short Quantity
		{
			get;
			set;
		}

        public Cash Cash
        {
            get;
            set;
        }
    }
}
