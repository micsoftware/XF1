using System;
using ReactiveUI;
using Xamarin.Forms;

namespace XF1.ViewModels
{
    public class HomePageViewModel: PageViewModelBase
    {
        public HomePageViewModel(Page page): base(page)
        {
        }

        private string welcomeMessage = "Welcome to Xamarin.Forms! using ReactiveUI";
        public string WelcomeMessage
        {
            get { return welcomeMessage; }
            set
            {
                this.RaisePropertyChanging(nameof(WelcomeMessage));
                welcomeMessage = value;
                this.RaisePropertyChanged(nameof(welcomeMessage));
            }
        } 

    }
}
