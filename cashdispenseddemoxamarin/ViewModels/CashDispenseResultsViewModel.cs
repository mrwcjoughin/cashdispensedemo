using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

using Models;

namespace cashdispenseddemoxamarin.ViewModels
{
    public class CashDispenseResultsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<CashDispenseResult> CashDispenseResults { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CashDispenseResultsViewModel()
        {
            Title = "Transactions";
            CashDispenseResults = new ObservableRangeCollection<CashDispenseResult>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewCashDispenseResultPage, CashDispenseResultNewViewModel>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as CashDispenseResultNewViewModel;
                await CashDispenseResultDataStore.AddItemAsync(_item.NewCashDispenseResult);
                await ExecuteLoadItemsCommand();
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                CashDispenseResults.Clear();
                var items = await CashDispenseResultDataStore.GetItemsAsync(true);
                CashDispenseResults.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
