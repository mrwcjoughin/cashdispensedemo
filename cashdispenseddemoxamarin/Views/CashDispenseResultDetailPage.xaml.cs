using System;
using System.Collections.Generic;

using Xamarin.Forms;

using cashdispenseddemoxamarin.ViewModels;

namespace cashdispenseddemoxamarin
{
    public partial class CashDispenseResultDetailPage : ContentPage
    {
        CashDispenseResultDetailViewModel viewModel;

        public CashDispenseResultDetailPage(CashDispenseResultDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
