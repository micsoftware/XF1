using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF1;
using XF1.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XF1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = GetMainPage();
            //MainPage = new MainPage();
        }

        private static Page GetMainPage()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.ViewModel = new LoginPageViewModel(loginPage);
            return loginPage; 
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
