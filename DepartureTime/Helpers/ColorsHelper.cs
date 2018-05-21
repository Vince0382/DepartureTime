using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Reflection;

namespace DepartureTime.Helpers
{
    public static class ColorsHelper
    {
        public static ObservableCollection<String> GetColorList ()
        {
            ObservableCollection<String> colorNames = new ObservableCollection<string>();

            IList<String> tmpColors = typeof(Color).GetRuntimeFields()
                                        .Where(f => f.IsPublic && f.IsStatic)
                                        .Select(f => f.Name).ToList();

            foreach (string tmpColor in tmpColors)
            {
                colorNames.Add(tmpColor);
            }
       
            return colorNames;
        }

        public static string ColorToString(Color c)
        {
            string result = "Black";
            ColorTypeConverter _colorTypeConverter = new ColorTypeConverter();


            foreach(string tmpC in GetColorList())
            {
                if ((Color)_colorTypeConverter.ConvertFromInvariantString(tmpC) == c)
                    return tmpC;
            }

            return result;
        }

        public static Color StringToColor(string c)
        {
            if (!string.IsNullOrEmpty(c))
            {
                ColorTypeConverter _colorTypeConverter = new ColorTypeConverter();
                return (Color)_colorTypeConverter.ConvertFromInvariantString(c);
            }

            return Color.Black;
        }
      
    }
}
