
using DepartureTime.Droid;
using Android.Content;
using DepartureTime.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(TimePicker), typeof(CustomTimePickerRenderer))] 
[assembly: ExportRenderer(typeof(CustomTimePicker24H), typeof(CustomTimePickerRenderer))] 
namespace DepartureTime.Droid
{
	public class CustomTimePickerRenderer : TimePickerRenderer
	{

		public CustomTimePickerRenderer(Context context) : base(context)
		{
		}
        
		public static void Init() { }

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TimePicker> e)
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

            if (!string.IsNullOrEmpty(Element.FontFamily))
            {
                Control.SetTypeface(TTFToFontHelper.GetTypeFaceFromFile(Element.FontFamily), TypefaceStyle.Normal);
            }
        }
	}
}
