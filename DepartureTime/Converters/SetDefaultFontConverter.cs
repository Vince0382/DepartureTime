using System;
using Xamarin.Forms;

namespace DepartureTime.Converters
{
	public class SetDefaultFontConverter : IValueConverter
    {
		#region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
			if (string.IsNullOrEmpty((string)value))
				return "Default";

			return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
			if ((string)value == "Default")
				return string.Empty;

			return value;
        }

        #endregion
    }
}
