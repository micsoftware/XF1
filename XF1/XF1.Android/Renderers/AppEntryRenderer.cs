using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XF1;
using XF1.Droid;

[assembly: ExportRenderer(typeof(EntryApp), typeof(AppEntryRenderer))]
namespace XF1.Droid
{

    class AppEntryRenderer : EntryRenderer
    {
        public AppEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if ((Element != null) && (Element is EntryApp))
            {
                if ((Element as EntryApp).IsClearBackground == true)
                {
                    Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    Element.Margin = new Thickness(0, 0, 0, -5);
                    Control.SetPadding(0, 0, 0, 0);
                }
            } 
        } 
    }
}
