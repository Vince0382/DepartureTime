using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using DepartureTime.iOS;
using DepartureTime.CustomControls;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
[assembly: ExportRenderer(typeof(CustomFontPicker), typeof(CustomPickerRenderer))]
namespace DepartureTime.iOS
{
    public class CustomPickerRenderer : PickerRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            
            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}

