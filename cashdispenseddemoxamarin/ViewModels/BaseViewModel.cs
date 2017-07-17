using Xamarin.Forms;

using Models;
using cashdispenseddemoxamarin.Services;

namespace cashdispenseddemoxamarin.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public CashDispenseDueCloudDataStore CashDispenseDueCloudDataStore => DependencyService.Get<CashDispenseDueCloudDataStore>();
        public CashDispenseResultCloudDataStore CashDispenseResultDataStore => DependencyService.Get<CashDispenseResultCloudDataStore>();
        public UserCloudDataStore UserDataStore => DependencyService.Get<UserCloudDataStore>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
