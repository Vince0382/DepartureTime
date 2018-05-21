using System.Collections.ObjectModel;
using Xamarin.Forms;
using UIKit;
using DepartureTime.iOS.Helpers;
using DepartureTime.Interfaces;

[assembly: Dependency(typeof(FontHelper))]
namespace DepartureTime.iOS.Helpers
{
	public class FontHelper : IFontProvider
    {

        public ObservableCollection<string> GetFonts()
		{
			var familyNames = UIFont.FamilyNames;

            ObservableCollection<string> itemSource = new ObservableCollection<string>();

            foreach (var familyName in familyNames)
            {
                var fontNames = UIFont.FontNamesForFamilyName(familyName);
                foreach (var fontName in fontNames)
                {
                    itemSource.Add(fontName);
                }
            }

            return itemSource;         
		}
      
    }
}
