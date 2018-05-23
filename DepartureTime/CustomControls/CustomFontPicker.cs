using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using DepartureTime.Interfaces;

namespace DepartureTime.CustomControls
{
	public class CustomFontPicker : Picker
    {
        public CustomFontPicker()
		{
			List<string> itemSource = DependencyService.Get<IFontProvider>().GetFonts();
			itemSource.Add("Default");

			ItemsSource = itemSource;
        }
    }
}
