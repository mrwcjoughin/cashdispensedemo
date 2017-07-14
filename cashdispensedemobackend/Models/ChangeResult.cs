using System;

namespace cashdispensedemobackend.Models
{
    public class Cash
    {
        public Cash()
        {
        }

        public decimal Number
        {
            get;
            set;
        }

		public string Denomination
		{
			get;
			set;
		}
    }
}
