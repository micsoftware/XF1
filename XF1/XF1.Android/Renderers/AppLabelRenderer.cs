using System;
using System.ComponentModel;
using Android.Content;
using Android.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XF1;
using XF1.Droid;

[assembly: ExportRenderer(typeof(LabelApp), typeof(AppLabelRenderer))]
namespace XF1.Droid
{
    public class AppLabelRenderer : LabelRenderer
    {
        public AppLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;


            //if (this.Element != null)
            //{
            //    if (this.Element.FontAttributes == FontAttributes.Bold)
            //    {
            //        this.Element.FontFamily = Appearance.Instance.FontFamilyBold;
            //    }
            //    else
            //    {
            //        this.Element.FontFamily = Appearance.Instance.FontFamilyDefault;
            //    }
            //}

            if (this.Element is LabelApp)
            {
                (e.NewElement as LabelApp).PropertyChanged += NewElement_PropertyChanged;

                if ((e.NewElement as LabelApp).UnderLine)
                {
                    this.Control.PaintFlags = this.Control.PaintFlags | Android.Graphics.PaintFlags.UnderlineText;
                }

                if (this.Element != null && (this.Element as LabelApp).Lines != -1 && Control != null)
                {
                    Control.SetMaxLines((this.Element as LabelApp).Lines);
                    Control.SetLines((this.Element as LabelApp).Lines);
                    Control.Ellipsize = TextUtils.TruncateAt.End;
                }

            }

        }

        void NewElement_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.Element is LabelApp)
            {
                if (e.PropertyName == nameof(LabelApp.Text))
                {
                    if ((this.Element as LabelApp).UnderLine)
                    {
                        this.Control.PaintFlags = this.Control.PaintFlags | Android.Graphics.PaintFlags.UnderlineText;
                    }
                }

            }
        }
    }
}
