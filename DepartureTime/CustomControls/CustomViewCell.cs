using System;
using Xamarin.Forms;

namespace DepartureTime.CustomControls
{
    public class CustomViewCell : ViewCell
    {
        public static readonly BindableProperty BackgroundColorProperty =
                                BindableProperty.Create("BackgroundColor",
                                typeof(Color),
                                typeof(CustomViewCell),
                                Color.Default);

        public Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }
        }
}
