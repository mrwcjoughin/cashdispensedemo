using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Models;
using cashdispenseddemoxamarin.ViewModels;

namespace cashdispenseddemoxamarin
{
    public partial class NewCashDispenseResultPage : ContentPage
    {
        public NewCashDispenseResultPage()
        {
            InitializeComponent();

            BindingContext = new CashDispenseResultNewViewModel();
        }

        public CashDispenseResultNewViewModel ViewModel
        {
            get
            {
                return (CashDispenseResultNewViewModel)BindingContext;
            }
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", ViewModel);
            await Navigation.PopToRootAsync();
        }
    }
}
