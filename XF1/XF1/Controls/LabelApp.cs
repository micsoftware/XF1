using System;
using Xamarin.Forms;

namespace XF1
{
    public class LabelApp : Label
    {
        private static int _defaultLineSetting = -1;

        public static readonly BindableProperty LinesProperty = BindableProperty.Create(nameof(Lines), typeof(int), typeof(LabelApp), _defaultLineSetting);
        public int Lines
        {
            get { return (int)GetValue(LinesProperty); }
            set { SetValue(LinesProperty, value); }
        }

        private string mHtmlText;
        public string HtmlText
        {
            get
            {
                return mHtmlText;
            }
            set
            {
                OnPropertyChanging(nameof(HtmlText));
                mHtmlText = value;
                OnPropertyChanged(nameof(HtmlText));
            }
        }

        private bool mUnderLine;
        public bool UnderLine
        {
            get
            {
                return mUnderLine;
            }
            set
            {
                OnPropertyChanging(nameof(UnderLine));
                mUnderLine = value;
                OnPropertyChanged(nameof(UnderLine));
            }
        }

        public LabelApp()
        {
        }
    }
}
