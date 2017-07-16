using System;
using System.Diagnostics;
using System.Threading.Tasks;
using cashdispenseddemoxamarin.Models;
using Xamarin.Forms;

namespace cashdispenseddemoxamarin.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public ObservableRangeCollection<User> Users { get; set; }
        public Command LoadItemsCommand { get; set; }

        public UsersViewModel()
        {
            Title = "Browse";
            Users = new ObservableRangeCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Users.Clear();
                var items = await UserDataStore.GetItemsAsync(true);
                Users.ReplaceRange(items);
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
