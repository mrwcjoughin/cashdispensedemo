using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using Models;
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
