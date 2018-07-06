using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF1.ViewModels;
using ReactiveUI;

namespace XF1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPageBase<LoginPageViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
            bool init = true;

            this.WhenActivated((obj) =>
            {
                if (init)
                {
                    if (this.ViewModel != null)
                    {
                        init = false;
                    }
                }
            });
        }
    }
}
