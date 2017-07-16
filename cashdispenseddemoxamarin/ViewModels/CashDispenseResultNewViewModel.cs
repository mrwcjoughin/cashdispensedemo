using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using cashdispenseddemoxamarin.Models;

namespace cashdispenseddemoxamarin.ViewModels
{
    public class CashDispenseResultNewViewModel : BaseViewModel
    {
        public CashDispenseResult CashDispenseResult { get; set; }

        public CashDispenseResultNewViewModel()
        {
            CashDispenseResult = new CashDispenseResult();


        }
    }
}
