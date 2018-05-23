using System.Collections.ObjectModel;
using System.Collections.Generic;
using DepartureTime.Interfaces;
using Xamarin.Forms;
using DepartureTime.Droid;
using Java.IO;
using Android.Graphics;

[assembly: Dependency(typeof(FontHelper))]
namespace DepartureTime.Droid
{
	public class FontHelper : IFontProvider
    {
		public List<string> GetFonts()
        {

			File file = TTFToFontHelper.GetFile();
			File[] ff = file.ListFiles();

            List<string> itemSource = new List<string>();

            foreach(File filename in ff)
			{
				itemSource.Add(filename.Name);
			}

			itemSource.Sort();

			return itemSource;
        } 
        
    }
}
