using Java.IO;
using Android.Graphics;

namespace DepartureTime.Droid
{
    public static class TTFToFontHelper
    {
		private static string fontPath = "/system/fonts";

		public static File GetFile()
		{
			return new File(fontPath);
		}

        public static Typeface GetTypeFaceFromFile(string fontFamily)
		{
			File fontFile = new File(fontPath + "/" + fontFamily);
            Typeface typeFace = Typeface.CreateFromFile(fontFile);

			return typeFace;
		}
    }
}
