using System;

namespace Models
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
