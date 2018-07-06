using System;
using System.Diagnostics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF1;
using XF1.iOS.Renderers;

[assembly: ExportRenderer(typeof(FrameApp), typeof(AppFrameRenderer))]
namespace XF1.iOS.Renderers
{
    public class AppFrameRenderer : FrameRenderer
    {
        public override void TouchesBegan(Foundation.NSSet touches, UIKit.UIEvent evt)
        {
            if (this.Element is FrameApp)
            {
                UITouch touch = touches.AnyObject as UITouch;
                var location = touch.LocationInView(this.Self as UIKit.UIView);
                (this.Self as UIKit.UIView).BackgroundColor = (this.Element as FrameApp).TouchBackgroundColor.ToUIColor();
            }
            base.TouchesBegan(touches, evt);


        }

        public override void TouchesMoved(Foundation.NSSet touches, UIKit.UIEvent evt)
        {
            if (this.Element is FrameApp)
            {
                (this.Self as UIKit.UIView).BackgroundColor = (this.Element as FrameApp).TouchBackgroundColor.ToUIColor();
            }
            base.TouchesMoved(touches, evt);

        }

        public override void TouchesCancelled(Foundation.NSSet touches, UIKit.UIEvent evt)
        {
            if (this.Element is FrameApp)
            {
                UITouch touch = touches.AnyObject as UITouch;
                var location = touch.LocationInView(this.Self as UIKit.UIView);
                (this.Self as UIKit.UIView).BackgroundColor = (this.Element as FrameApp).BackgroundColor.ToUIColor();
                (this.Element as FrameApp).RaiseTouchUp();
            }
            base.TouchesCancelled(touches, evt);

        }

        public override void TouchesEnded(Foundation.NSSet touches, UIKit.UIEvent evt)
        {
            if (this.Element is FrameApp)
            {
                (this.Self as UIKit.UIView).BackgroundColor = (this.Element as FrameApp).BackgroundColor.ToUIColor();
                (this.Element as FrameApp).RaiseTouchUp();
            }
            base.TouchesEnded(touches, evt);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            CreateCircle();

        }


        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName)
            {
                CreateCircle();
            }
        }

        private void CreateCircle()
        {

            try
            {
                if (Element is FrameApp && (Element as FrameApp).IsCircle)
                {
                    double min = Math.Min(Element.Width, Element.Height);
                    Element.WidthRequest = min;
                    Element.HeightRequest = min;
                    (Element as FrameApp).CornerRadius = (float)(min / 2.0);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to create circle image: " + ex);
            }
        }
    }
}
