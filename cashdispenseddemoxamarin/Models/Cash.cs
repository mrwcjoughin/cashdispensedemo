using System;

namespace Models
{
    public class Cash
    {
        public Cash()
        {
        }

		public string Number
		{
			get;
			set;
		}

		public string NumberFormatted
		{
			get
			{
                return String.Format("{0:0.00}", decimal.Parse(Number));
			}
		}

		public string Denomination
		{
			get;
			set;
		}
    }
}