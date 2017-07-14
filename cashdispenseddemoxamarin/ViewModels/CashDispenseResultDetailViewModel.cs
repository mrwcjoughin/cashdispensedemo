using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using cashdispenseddemoxamarin.Models;

namespace cashdispenseddemoxamarin.ViewModels
{
    public class CashDispenseResultDetailViewModel : BaseViewModel
    {
        public CashDispenseResult CashDispenseResult { get; set; }

        public CashDispenseResultDetailViewModel(CashDispenseResult item = null)
        {
            //Title = item.Text;
            CashDispenseResult = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}
