using System;
using System.Collections.Generic;

using Xamarin.Forms;
using cashdispenseddemoxamarin.Models;

namespace cashdispenseddemoxamarin
{
    public partial class NewCashDispenseResultPage : ContentPage
    {
        public CashDispenseResult CashDispenseResult { get; set; }

        public NewCashDispenseResultPage()
        {
            InitializeComponent();

            CashDispenseResult = new CashDispenseResult
            {
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", CashDispenseResult);
            await Navigation.PopToRootAsync();
        }
    }
}
