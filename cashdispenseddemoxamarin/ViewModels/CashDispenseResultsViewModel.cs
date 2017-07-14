using System;
using System.Diagnostics;
using System.Threading.Tasks;
using cashdispenseddemoxamarin.Models;
using Xamarin.Forms;

namespace cashdispenseddemoxamarin.ViewModels
{
    public class CashDispenseResultsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<CashDispenseResult> CashDispenseResults { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CashDispenseResultsViewModel()
        {
            Title = "Browse";
            CashDispenseResults = new ObservableRangeCollection<CashDispenseResult>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewCashDispenseResultPage, CashDispenseResult>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as CashDispenseResult;
                CashDispenseResults.Add(_item);
                await DataStore.AddItemAsync(_item);
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
                var items = await DataStore.GetItemsAsync(true);
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
