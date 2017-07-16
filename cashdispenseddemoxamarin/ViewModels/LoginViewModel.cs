using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using cashdispenseddemoxamarin.Models;
using Xamarin.Forms;

namespace cashdispenseddemoxamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private UserCloudDataStore _userCloudDataStore;

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await SignIn());
            NotNowCommand = new Command(App.GoToMainPage);

            _userCloudDataStore = DependencyService.Get<UserCloudDataStore>();
        }

        string message = string.Empty;
        public string Message
        {
            get 
            {
                return message; 
            }
            set 
            {
                message = value; 
                OnPropertyChanged(); 
            }
        }

		string userName = string.Empty;
		public string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				userName = value;
				OnPropertyChanged("UserName");
			}
		}

		string password = string.Empty;
		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				password = value;
				OnPropertyChanged("Password");
			}
		}

        public ICommand NotNowCommand { get; }
        public ICommand LoginCommand { get; }

        async Task SignIn()
        {
            try
            {
                Message = "Signing In...";

                // Log the user in
                Settings.UserId = await TryLoginAsync();
            }
            finally
            {
                Message = string.Empty;
                IsBusy = false;

                if (Settings.IsLoggedIn)
                    App.GoToMainPage();
            }
        }

        public async Task<string> TryLoginAsync()
        {
            if (IsBusy)
            {
                return string.Empty;
            }

			IsBusy = true;

			try
			{
                User user = new User();

                user.UserName = this.UserName;
                user.Password = this.Password;

				var result = await _userCloudDataStore.LoginAsync(user);

                return result;
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

            return string.Empty;
        }
    }
}
