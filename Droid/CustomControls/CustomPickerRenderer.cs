using DepartureTime.Droid;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace DepartureTime.Droid
{
	public class CustomPickerRenderer : PickerRenderer
	{
		public CustomPickerRenderer(Context context) : base(context)
        {
        }

        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;

                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(15, 15, 15, 15);
                SetPadding(0, 0, 0, 0);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            
			Control.SetTypeface(TTFToFontHelper.GetTypeFaceFromFile(Element.FontFamily), TypefaceStyle.Normal);
            
        }
	}
}
