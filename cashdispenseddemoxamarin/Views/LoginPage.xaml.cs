using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cashdispenseddemoxamarin
{
    [XamlCompilation (XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            Resources = new StylesPage().Resources;
            InitializeComponent();
        }
    }
}