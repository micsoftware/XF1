using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Xamarin.Forms;

namespace XF1.ViewModels
{
    public class LoginPageViewModel : PageViewModelBase
    {
        public LoginPageViewModel(Page page) : base(page)
        {
        }  

        string email = "hello@world.com";
        public string Email
        {
            get { return email; }
            set
            {
                this.RaisePropertyChanging(nameof(Email));
                email = value;
                this.RaisePropertyChanged(nameof(Email));
            }
        }

        string password = "admin";
        public string Password
        {
            get { return password; }
            set
            {
                this.RaisePropertyChanging(nameof(Password));
                password = value;
                this.RaisePropertyChanged(nameof(Password));
            }
        }

        public ICommand SignInCommand
        {
            get
            {
                return ReactiveCommand.Create(async () =>
                {
                    await ExecuteLoginCommandAsync();
                });
            }
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if(email == "hello@world.com" && password == "admin")
            {
                var homePage = new HomePage();
                homePage.ViewModel = new HomePageViewModel(homePage);
                Application.Current.MainPage = new NavigationPage(homePage);
            }
            else 
            {
                await this.Page.DisplayAlert("Login", "Enter valid Credentials", "OK"); 
            }

        }
    }
}
