using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XF1
{
    public class FrameApp : Frame
    {
        public bool is_set_radius = false;

        public static readonly BindableProperty TouchUpProperty =
         BindableProperty.Create("TouchUp",
                                 typeof(ICommand),
                                 typeof(FrameApp),
                                 null);

        public ICommand TouchUp
        {
            get { return (ICommand)GetValue(TouchUpProperty); }
            set { SetValue(TouchUpProperty, value); }
        }

        //public ICommand TouchUp { get; set; }
        public void RaiseTouchUp()
        {
            if (TouchUp != null)
            {
                TouchUp.Execute(null);
            }
        }


        public Boolean IsCircle { get; set; } = false;

        public Color TouchBackgroundColor { get; set; } = Color.Transparent;


        private float mRadiusRatio;
        public float RadiusRatio
        {
            get
            {
                return mRadiusRatio;
            }
            set
            {
                OnPropertyChanging(nameof(RadiusRatio));
                mRadiusRatio = value;
                this.CornerRadius = (int)(this.Height * RadiusRatio);
                OnPropertyChanged(nameof(RadiusRatio));
            }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(FrameApp), Color.Default,
                                            propertyChanged: OnBorderColorPropertyChanged);

        static void OnBorderColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as FrameApp).BorderColor = (Color)newValue;
        }

        private Color mBorderColor = Color.Transparent;
        public Color BorderColor
        {
            get
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    return mBorderColor;
                }
                else
                {
                    return OutlineColor;
                }
            }
            set
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    mBorderColor = value;
                }
                else
                {
                    OutlineColor = value;
                }
            }
        }

        public FrameApp()
        {


            this.SizeChanged += (sender, e) =>
            {
                if (RadiusRatio > 0)
                {
                    try
                    {
                        float cornerRadius = (float)(this.Height * RadiusRatio);
                        if (!cornerRadius.Equals(this.CornerRadius))
                        {
                            this.CornerRadius = cornerRadius;
                        }
                    }
                    catch (Exception)
                    {
                        //fix Android Frame Xamarin bug   
                    }
                }
            };
        }
    }
}
