using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;
using UIKit;
using DepartureTime.iOS.Helpers;
using DepartureTime.Interfaces;

[assembly: Dependency(typeof(FontHelper))]
namespace DepartureTime.iOS.Helpers
{
	public class FontHelper : IFontProvider
    {

        public List<string> GetFonts()
		{
			var familyNames = UIFont.FamilyNames;

            List<string> itemSource = new List<string>();

            foreach (var familyName in familyNames)
            {
                var fontNames = UIFont.FontNamesForFamilyName(familyName);
                foreach (var fontName in fontNames)
                {
                    itemSource.Add(fontName);
                }
            }

			itemSource.Sort();

            return itemSource;         
		}

    }
}
