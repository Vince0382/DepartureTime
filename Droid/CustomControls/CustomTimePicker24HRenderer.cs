using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Android.Widget;
using DepartureTime.Droid;
using DepartureTime.CustomControls;
using Android.Content;

[assembly: ExportRenderer(typeof(CustomTimePicker24H), typeof(CustomTimePicker24HRenderer))]   
namespace DepartureTime.Droid   
{

    public class CustomTimePicker24HRenderer : TimePickerRenderer
    {
        public CustomTimePicker24HRenderer(Context context) : base(context)
        {
        }

        private EditText _TextField { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TimePicker> e)
        {
            base.OnElementChanged(e);

            if (_TextField == null)
            {
                _TextField = new EditText(this.Context)
                {
                    Focusable = false,
                    Clickable = false,
                    Tag = this
                };

                _TextField.Click += TextField_Click;
                SetNativeControl(_TextField);
            }

            _TextField.Text = DateTime.Today.Add(Element.Time).ToString(Element.Format);
        }

        private void TextField_Click(object sender, EventArgs e)
        {
            new TimePickerDialog(this.Context, new EventHandler<TimePickerDialog.TimeSetEventArgs>(OnTimeSet), Element.Time.Hours, Element.Time.Minutes, true).Show();
        }

        private void OnTimeSet(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            Element.Time = new TimeSpan(e.HourOfDay, e.Minute, 0);
            _TextField.Text = DateTime.Today.Add(Element.Time).ToString(Element.Format);
        }
    }


} 
