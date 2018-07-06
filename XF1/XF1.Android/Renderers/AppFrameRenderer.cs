using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XF1;
using XF1.Droid;

[assembly: ExportRenderer(typeof(FrameApp), typeof(AppFrameRenderer))]
namespace XF1.Droid
{
    public class AppFrameRenderer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    {
        private Xamarin.Forms.Color default_background = Xamarin.Forms.Color.White;
        public AppFrameRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            try
            {
                base.OnElementChanged(e);
                if (e.OldElement != null || this.Element == null)
                    return;
                if (this.Control != null && this.Element is FrameApp)
                {
                    //this.Control.SetBackgroundColor((this.Element as FrameApp).BackgroundColor.ToAndroid());
                    this.Control.Touch += ViewGroup_Touch;
                }
            }
            catch (Exception es)
            {
                base.OnElementChanged(e);
            }
        }

        private void ViewGroup_Touch(object sender, TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                if (this.Control != null && this.Element is FrameApp)
                {
                    // this.Control.SetBackgroundColor((this.Element as FrameApp).TouchBackgroundColor.ToAndroid());
                    this.default_background = this.Element.BackgroundColor;
                    this.Element.BackgroundColor = (this.Element as FrameApp).TouchBackgroundColor;
                }
            }
            else if (e.Event.Action == MotionEventActions.Up
                || e.Event.Action == MotionEventActions.PointerUp)
            {
                if (this.Control != null && this.Element is FrameApp)
                {
                    //this.Control.SetBackgroundColor((this.Element as FrameApp).BackgroundColor.ToAndroid());
                    this.Element.BackgroundColor = this.default_background;
                    if ((this.Element as FrameApp).TouchUp != null)
                    {
                        (this.Element as FrameApp).RaiseTouchUp();
                    }
                }
            }
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            if (Element is FrameApp && (Element as FrameApp).IsCircle)
            {

                double min = Math.Min(w, h);
                int width_height = (int)min;
                float corner_value = (float)this.Context.FromPixels(width_height / 2);

                (Element as FrameApp).CornerRadius = corner_value;
                base.OnSizeChanged(width_height, width_height, oldw, oldh);
            }
            else
            {
                base.OnSizeChanged(w, h, oldw, oldh);
            }

        }


        protected override void OnDraw(Android.Graphics.Canvas canvas)
        {
            base.OnDraw(canvas);
            DrawOutline(canvas, canvas.Width, canvas.Height);

        }

        void DrawOutline(Android.Graphics.Canvas canvas, int width, int height)
        {
            if (this.Element is FrameApp)
            {
                int strokeWidth = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 1, Context.Resources.DisplayMetrics);

                using (var paint = new Paint { AntiAlias = true })
                using (var path = new Path())
                using (Path.Direction direction = Path.Direction.Cw)
                using (Paint.Style style = Paint.Style.Stroke)


                using (var rect = new RectF(strokeWidth + strokeWidth / 2, strokeWidth + strokeWidth / 2, width - strokeWidth - strokeWidth / 2, height - strokeWidth - strokeWidth / 2))
                {
                    if (this.Element.CornerRadius > 0)
                    {
                        float rx = this.Context.ToPixels(this.Element.CornerRadius);
                        float ry = this.Context.ToPixels(this.Element.CornerRadius);

                        path.AddRoundRect(rect, rx, ry, direction);
                    }
                    else
                    {
                        path.AddRect(rect, direction);
                    }
                    paint.StrokeWidth = strokeWidth;  //set outline stroke
                    paint.SetStyle(style);
                    paint.Color = (this.Element as FrameApp).BorderColor.ToAndroid();

                    canvas.DrawPath(path, paint);
                }
            }
        }





        //protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);
        //    if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
        //        e.PropertyName == VisualElement.WidthProperty.PropertyName)
        //    {
        //        CreateCircle();
        //    }
        //}

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
                // Debug.WriteLine("Unable to create circle image: " + ex);
            }
        }
    }
}
