using System;
using Xamarin.Forms;
using DepartureTime.Helpers;

namespace DepartureTime.CustomControls
{
    public class CustomColorPicker : Picker
    {

        public CustomColorPicker()
        {
            ItemsSource = ColorsHelper.GetColorList();
        }
    }
}
