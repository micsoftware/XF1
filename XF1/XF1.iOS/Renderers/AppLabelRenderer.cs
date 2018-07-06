using System;
using System.ComponentModel;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF1;
using XF1.iOS.Renderers;

[assembly: ExportRenderer(typeof(LabelApp), typeof(AppLabelRenderer))]
namespace XF1.iOS.Renderers
{
    public class AppLabelRenderer : LabelRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;

            e.NewElement.PropertyChanged += NewElement_PropertyChanged;



            if (e.NewElement is LabelApp && this.Control != null)
            {
                LabelApp labelApp = (e.NewElement as LabelApp);
                if (labelApp.UnderLine)
                {
                    this.Control.AttributedText = new NSAttributedString(
                        e.NewElement.Text,
                        underlineStyle: NSUnderlineStyle.Single);
                }
                if (this.Element != null && (this.Element as LabelApp).Lines != -1 && Control != null)
                {
                    Control.Lines = (this.Element as LabelApp).Lines;
                    Control.LineBreakMode = UIKit.UILineBreakMode.TailTruncation;
                }



            }
        }

        //protected override void OnElementChanged(ElementChangedEventArgs<LabelApp> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.OldElement != null || this.Element == null)
        //        return;

        //    if (e.OldElement != null)
        //        e.OldElement.PropertyChanged -= OnElementPropertyChanged;

        //    e.NewElement.PropertyChanged += NewElement_PropertyChanged;

        //    if (this.Control == null)
        //    {
        //        var yourTextView = new UITextView();

        //        yourTextView.Editable = false;
        //        yourTextView.DataDetectorTypes = UIDataDetectorType.All;
        //              yourTextView.BackgroundColor = Color.Transparent.ToUIColor();
        //              yourTextView.TintColor = Color.FromRgb(100, 100, 100).ToUIColor();
        //        //webView.SetWebChromeClient(new ChromeClient());

        //        SetNativeControl(yourTextView);

        //        if (!string.IsNullOrEmpty((e.NewElement as LabelApp).HtmlText))
        //        {
        //            var attr = new NSAttributedStringDocumentAttributes();
        //            var nsError = new NSError();
        //            attr.DocumentType = NSDocumentType.HTML;
        //            var myHtmlData = NSData.FromString((e.NewElement as LabelApp).HtmlText, NSStringEncoding.Unicode);
        //            this.Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);
        //            //this.Control.Font = UIFont.FromName(iOS.Appearance.Instance.FontNameDefault, (nfloat)Math.Ceiling(e.NewElement.FontSize));
        //        }    
        //    }
        //}

        void NewElement_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.Element is LabelApp && this.Control != null)
            {
                LabelApp labelApp = this.Element as LabelApp;

                if (e.PropertyName == nameof(Label.Text))
                {
                    if (labelApp.UnderLine)
                    {
                        this.Control.AttributedText = new NSAttributedString(
                            this.Element.Text,
                            underlineStyle: NSUnderlineStyle.Single);
                    }
                }
                if (e.PropertyName == nameof(LabelApp.Lines))
                {
                    if (labelApp.Lines > 0)
                    {
                        this.Control.Lines = labelApp.Lines;
                    }
                }

                //if (e.PropertyName == nameof(Label.Text))
                //{
                //    var attr = new NSAttributedStringDocumentAttributes();
                //    var nsError = new NSError();
                //    attr.DocumentType = NSDocumentType.HTML;

                //    var myHtmlData = NSData.FromString((this.Element as LabelApp).HtmlText, NSStringEncoding.Unicode);
                //    this.Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);
                //}
            }
        }
    }
}
