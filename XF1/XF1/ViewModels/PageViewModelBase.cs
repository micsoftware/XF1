using System;
using Xamarin.Forms;

namespace XF1.ViewModels
{
    public class PageViewModelBase : ViewModelBase
    {
        public PageViewModelBase(Page page)
        {
            Page = page;
        }

        public virtual Page Page
        {
            get;
            set;
        }
    }
}
