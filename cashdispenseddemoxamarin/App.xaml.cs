using System.Collections.Generic;

using Xamarin.Forms;

using cashdispenseddemoxamarin.Services;

namespace cashdispenseddemoxamarin
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = false;
        public static string BackendUrl = "http://localhost:58239";

        public static IDictionary<string, string> LoginParameters => null;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
            {
                DependencyService.Register<MockDataStore>();
            }
            else
            {
                DependencyService.Register<CashDispenseDueCloudDataStore>();
                DependencyService.Register<CashDispenseResultCloudDataStore>();
                DependencyService.Register<UserCloudDataStore>();
            }

            SetMainPage();
        }

        public static void SetMainPage()
        {
            if (!UseMockDataStore && !Settings.IsLoggedIn)
            {
                Current.MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = (Color)Current.Resources["Primary"],
                    BarTextColor = Color.White
                };
            }
            else
            {
                GoToMainPage();
            }
        }

        public static void GoToMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children = {
                    new NavigationPage(new CashDispenseResultsPage())
                    {
                        Title = "Transactions",
                        Icon = Device.OnPlatform("tab_feed.png", null, null)
                    },
                }
            };
        }
    }
}
