using Xamarin.Forms;

using cashdispenseddemoxamarin.Models;
using cashdispenseddemoxamarin.Services;

namespace cashdispenseddemoxamarin.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<CashDispenseResult> CashDispenseResultDataStore => DependencyService.Get<IDataStore<CashDispenseResult>>();
        public IDataStore<User> UserDataStore => DependencyService.Get<IDataStore<User>>();

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
