using System;
using ReactiveUI;
using ReactiveUI.XamForms;
using XF1.ViewModels;

namespace XF1
{
    public abstract class ContentPageBase<T> : ReactiveContentPage<T> where T : PageViewModelBase
    {
        public ContentPageBase()
        {
            bool init = true;
            this.WhenActivated((obj) =>
            {
                if (init)
                {
                    init = false;
                    if (this.ViewModel != null)
                    {
                        this.ViewModel.BackAction = (t) =>
                        {
                            this.Navigation.PopAsync();
                        };
                    }
                }
            });

        }
    }
}
