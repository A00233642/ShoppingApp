using System;
using System.Threading.Tasks;
using ShoppingApp.Services;
using ShoppingApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShoppingApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Username;

        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();

            }

            get { return this._Username; }
        }

        private string _Password;

        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();

            }

            get { return this._Password; }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }

            get { return this._IsBusy; }
        }

        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }

            get { return this._Result; }
        }


        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsyn());
            RegisterCommand = new Command(async () => await RegisterCommandAsyn());
        }

        private async Task RegisterCommandAsyn()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.ResgisterUser(Username, Password);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "User already exists with these credentials", "OK");

            }

            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoginCommandAsyn()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if (Result)
                {
                    Preferences.Set("Username", Username);
                    //  await Application.Current.MainPage.Navigation.PopModalAsync(new ProductsView());
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "OK");
                }
            }

            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

            finally
            {
                IsBusy = false;
            }
        }

        private bool ProductsView()


        {
            throw new NotImplementedException();
        }
    }
}
