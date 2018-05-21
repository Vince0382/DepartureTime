using System;
using Xamarin.Forms;
using DepartureTime.Interfaces;

namespace DepartureTime.CustomControls
{
	public class CustomFontPicker : Picker
    {
        public CustomFontPicker()
        {         
			ItemsSource = DependencyService.Get<IFontProvider>().GetFonts();
        }
    }
}
