using System;
using Xamarin.Forms;

namespace XF1
{
    public class EntryApp : Entry
    {
        private bool mIsClearBackground = false;
        public bool IsClearBackground
        {
            get
            {
                return mIsClearBackground;
            }
            set
            {
                OnPropertyChanging(nameof(IsClearBackground));
                mIsClearBackground = value;
                OnPropertyChanged(nameof(IsClearBackground));
            }
        }

        public EntryApp()
        {
        }
    }
}
