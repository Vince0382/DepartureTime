using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using DepartureTime.iOS;
using DepartureTime.CustomControls;

[assembly: ExportRenderer(typeof(TimePicker), typeof(CustomTimePickerRenderer))]
[assembly: ExportRenderer(typeof(CustomTimePicker24H), typeof(CustomTimePickerRenderer))]
namespace DepartureTime.iOS
{
	public class CustomTimePickerRenderer : TimePickerRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);

            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}
