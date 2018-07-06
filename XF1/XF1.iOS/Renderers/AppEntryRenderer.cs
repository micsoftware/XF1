using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF1;
using XF1.iOS.Renderers;

[assembly: ExportRenderer(typeof(EntryApp), typeof(AppEntryRenderer))]
namespace XF1.iOS.Renderers
{
    /// <summary>
    /// This renderer fixes an issue with the carousel page and iOS 11 where the carousel page 
    /// has vertical scrolling besides the horizontal expected horizontal swipe.
    /// This render patches that behavior to prevent the vertical scroll.
    /// </summary>
    public class AppEntryRenderer : EntryRenderer
    {


        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if ((Element != null) && (Element is EntryApp))
            {
                if ((Element as EntryApp).IsClearBackground == true)
                {
                    Control.Layer.BorderColor = UIColor.Clear.CGColor;
                    Control.Layer.BorderWidth = 0;
                    Control.BorderStyle = UITextBorderStyle.None;
                }
            }
        }
    }
}
