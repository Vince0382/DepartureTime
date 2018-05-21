using System.Collections.ObjectModel;
using DepartureTime.Interfaces;
using Xamarin.Forms;
using DepartureTime.Droid;
using Java.IO;

[assembly: Dependency(typeof(FontHelper))]
namespace DepartureTime.Droid
{
	public class FontHelper : IFontProvider
    {
		public ObservableCollection<string> GetFonts()
        {

			File file = TTFToFontHelper.GetFile();
			File[] ff = file.ListFiles();

            ObservableCollection<string> itemSource = new ObservableCollection<string>();
            
            foreach(File filename in ff)
			{
				itemSource.Add(filename.Name);
			}
            
            return itemSource;
        } 
    }
}
