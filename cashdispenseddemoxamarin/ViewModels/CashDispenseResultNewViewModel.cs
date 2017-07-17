using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Models;
using cashdispenseddemoxamarin.Services;

namespace cashdispenseddemoxamarin.ViewModels
{
    public class CashDispenseResultNewViewModel : BaseViewModel
    {
        private CashDispenseResult _cashDispenseResult;

        public CashDispenseResult NewCashDispenseResult
        {
            get
            {
                return _cashDispenseResult;
            }
            set
            {
                _cashDispenseResult = value;
                OnPropertyChanged("NewCashDispenseResult");
            }
        }

        public CashDispenseResultNewViewModel()
        {
            Task.Run(async () =>
            {
                var cashDispenseResult = new CashDispenseResult();
                cashDispenseResult.CashDispenseDue = await base.CashDispenseDueCloudDataStore.GetItemAsync();

                cashDispenseResult.CashHandedOver = new Cash();
                cashDispenseResult.CashHandedOver.Denomination = cashDispenseResult.CashDispenseDue.AmountOwed.Denomination;

                this.NewCashDispenseResult = cashDispenseResult;
			});
        }
    }
}