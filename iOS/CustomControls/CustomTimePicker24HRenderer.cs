using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using DepartureTime.iOS;
using Foundation;
using DepartureTime.CustomControls;

[assembly: ExportRenderer(typeof(CustomTimePicker24H), typeof(CustomTimePicker24HRenderer))]
namespace DepartureTime.iOS
{
    public class CustomTimePicker24HRenderer : TimePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);
            var timePicker = (UIDatePicker)Control.InputView;
            timePicker.Locale = new NSLocale("no_nb");

            if (Control != null)
            {
                Control.Text = new DateTime().ToString("HH:mm");
            }
        }
    }

}