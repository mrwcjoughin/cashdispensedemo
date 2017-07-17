using System;
using System.Collections.Generic;

namespace Models
{
    public class CashDispenseResult
    {
        private string _changeFormatted = string.Empty;
        private decimal _changeTotal = 0m;

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

		public string ChangeFormatted
		{
			get
			{
                _changeFormatted = string.Empty;

                if (_changeFormatted == string.Empty)
                {
                    foreach (var item in ChangeResults)
                    {
                        if (_changeFormatted.Length > 0)
                        {
                            _changeFormatted += "\n";
                        }
                        _changeFormatted += item.Quantity.ToString() + " x " + (decimal.Parse(item.Cash.Number) > 1 ? item.Cash.Denomination + " " + item.Cash.NumberFormatted : item.Cash.NumberFormatted + " " + item.Cash.Denomination);
                        _changeTotal += decimal.Parse(item.Cash.Number) * (decimal)item.Quantity;
                    }

                    _changeFormatted += "\n\n";
                    _changeFormatted += "Total " + CashHandedOver.Denomination + String.Format("{0:0.00}", _changeTotal);
                }

				return _changeFormatted;
			}
		}
    }
}