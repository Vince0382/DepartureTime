﻿using System;
using Xamarin.Forms;
using DepartureTime.Helpers;

namespace DepartureTime.Converters
{

        public class StringToColorConverter : IValueConverter
        {

            #region IValueConverter implementation

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return ColorsHelper.ColorToString((Color)value);
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (!string.IsNullOrEmpty((string)value))
                {
                    ColorTypeConverter _colorTypeConverter = new ColorTypeConverter();
                    return (Color)_colorTypeConverter.ConvertFromInvariantString((string)value);
                }

                return Color.Default;
            }

            #endregion
        }
    }

