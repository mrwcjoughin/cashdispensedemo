using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using cashdispenseddemoxamarin.Models;
using Xamarin.Forms;

using cashdispenseddemoxamarin.ViewModels;

namespace cashdispenseddemoxamarin
{
    public partial class CashDispenseResultsPage : ContentPage
    {
        CashDispenseResultsViewModel viewModel;

        public CashDispenseResultsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CashDispenseResultsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as CashDispenseResult;
            if (item == null)
                return;

            await Navigation.PushAsync(new CashDispenseResultDetailPage(new CashDispenseResultDetailViewModel(item)));

            // Manually deselect item
            CashDispenseResultsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewCashDispenseResultPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.CashDispenseResults.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
