using System;
using System.Collections.Generic;
using ReactiveUI;
using Xamarin.Forms;
using XF1.ViewModels;

namespace XF1
{
    public partial class HomePage : ContentPageBase<HomePageViewModel>
    {
        public HomePage()
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
